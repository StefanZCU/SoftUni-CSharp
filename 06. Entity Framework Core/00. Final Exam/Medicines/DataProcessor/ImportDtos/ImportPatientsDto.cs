using Medicines.Data.Models.Enums;

namespace Medicines.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ImportPatientsDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string FullName { get; set; }

        [Required]
        [EnumDataType(typeof(AgeGroup))]
        public int AgeGroup { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public int Gender { get; set; }

        public int[] Medicines { get; set; }
    }

    //FullName – text with length[5, 100] (required)
    // •	AgeGroup – AgeGroup enum (Child = 0, Adult, Senior) (required)
    // •	Gender – Gender enum (Male = 0, Female) (required)
}
