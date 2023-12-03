using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmaciesDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; }

        [Required]
        [StringLength(14)]
        [RegularExpression(@"\(\d{3}\) \d{3}-\d{4}")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlArray("Medicines")]
        public ImportMedicineDto[] Medicines { get; set; }
        
    }
}
