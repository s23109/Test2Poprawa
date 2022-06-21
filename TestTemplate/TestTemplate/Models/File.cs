using System.ComponentModel.DataAnnotations;

namespace TestTemplate.Models
{
    public class File
    {
        [Required]
        public int FileID { get; set; }
        [Required]
        public int TeamID { get; set; }

        [MaxLength(100)]
        public string FileName { get; set; }

        [MaxLength(4)]
        public string FileExtention { get; set; }

        public int FileSize { get; set; }

        public virtual Team Team { get; set; }
    }
}
