using System.ComponentModel.DataAnnotations.Schema;

namespace Medicines.Data.Models
{
    public class PatientMedicine
    {
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [ForeignKey(nameof(Medicine))]
        public int MedicineId { get; set; }

        public virtual Medicine Medicine { get; set; }

    }

    //•	PatientId – integer, Primary Key, foreign key (required)
    // •	Patient – Patient
    // •	MedicineId – integer, Primary Key, foreign key (required)
    // •	Medicine – Medicine
    // 
}
