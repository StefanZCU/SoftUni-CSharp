using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Medicines.DataProcessor
{
    using Medicines.Data;

    public class Serializer
    {
        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(x => x.Category == (Category)medicineCategory && x.Pharmacy.IsNonStop)
                .ToArray()
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("0.00"),
                    Pharmacy = new ExportPharmacyDto
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ToList();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var patients = context.Patients
                .Where(x => x.PatientsMedicines.Count >= 1 && x.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > parsedDate))
                .ToArray()
                .Select(p => new ExportPatientsDto
                {
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                        .Where(pm => pm.Medicine.ProductionDate > parsedDate)
                        .OrderByDescending(x => x.Medicine.ExpiryDate)
                        .ThenBy(x => x.Medicine.Price)
                        .Select(m => new ExportMedicineDto()
                        {
                            Category = m.Medicine.Category.ToString().ToLower(),
                            Name = m.Medicine.Name,
                            Price = $"{m.Medicine.Price:0.00}",
                            Producer = m.Medicine.Producer,
                            BestBefore = m.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.Medicines.Length)
                .ThenBy(x => x.Name)
                .ToArray();

            return Serialize(patients, "Patients");
        }

        public static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            var sb = new StringBuilder();
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                NewLineChars = "\n",
                Encoding = Encoding.UTF8
            };

            using (var writer = XmlWriter.Create(sb, settings))
            {
                XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
                xmlNamespaces.Add(string.Empty, string.Empty);

                serializer.Serialize(writer, dataTransferObjects, xmlNamespaces);
            }

            return sb.ToString();
        }

    }
}
