using System.Globalization;
using System.Text;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Medicines.Extensions;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        private static XmlHelper xmlHelper;

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var sb = new StringBuilder();
            xmlHelper = new XmlHelper();

            ImportPharmaciesDto[] pharmaciesDtos =
                xmlHelper.Deserialize<ImportPharmaciesDto[]>(xmlString, "Pharmacies");

            ICollection<Pharmacy> validPharmacies = new HashSet<Pharmacy>();

            foreach (var pharmacy in pharmaciesDtos)
            {
                bool nonStop = bool.TryParse(pharmacy.IsNonStop, out bool result);

                if (!IsValid(pharmacy) || !nonStop)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                

                ICollection<Medicine> validMedicines = new HashSet<Medicine>();
                foreach (var medicine in pharmacy.Medicines)
                {
                    if (!IsValid(medicine) || string.IsNullOrEmpty(medicine.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (validMedicines.Any(x => x.Name == medicine.Name && x.Producer == medicine.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool productionDate = DateTime.TryParseExact(medicine.ProductionDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime production);

                    bool expiryDate = DateTime.TryParseExact(medicine.ExpiryDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiry);

                    if (!productionDate || !expiryDate || production >= expiry)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var medicineToAdd = new Medicine
                    {
                        Name = medicine.Name,
                        Price = (decimal)medicine.Price,
                        Category = (Category)medicine.Category,
                        ProductionDate = production,
                        ExpiryDate = expiry,
                        Producer = medicine.Producer
                    };

                    validMedicines.Add(medicineToAdd);
                }

                var pharmacyToAdd = new Pharmacy
                {
                    Name = pharmacy.Name,
                    PhoneNumber = pharmacy.PhoneNumber,
                    IsNonStop = result,
                    Medicines = validMedicines
                };

                validPharmacies.Add(pharmacyToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacyToAdd.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            ImportPatientsDto[] patientsDto = JsonConvert.DeserializeObject<ImportPatientsDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var patient in patientsDto)
            {
                if (!IsValid(patient) || string.IsNullOrEmpty(patient.FullName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var patientToAdd = new Patient
                {
                    FullName = patient.FullName,
                    AgeGroup = (AgeGroup)patient.AgeGroup,
                    Gender = (Gender)patient.Gender
                };

                foreach (var medicineId in patient.Medicines)
                {
                    if (patientToAdd.PatientsMedicines.Any(x => x.Medicine.Id == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    patientToAdd.PatientsMedicines.Add(new PatientMedicine
                    {
                        Patient = patientToAdd,
                        Medicine = context.Medicines.FirstOrDefault(x => x.Id == medicineId)
                    });
                }

                context.Patients.Add(patientToAdd);

                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patientToAdd.FullName, patientToAdd.PatientsMedicines.Count));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
