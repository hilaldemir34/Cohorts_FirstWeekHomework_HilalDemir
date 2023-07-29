using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Restful.WebApi.DAL.Entities
{
    public class Book
    {
        public int ID { get; set; }

        [DisplayName("Book Name")]
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Book Category")]
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        public string Category { get; set; }

        [DisplayName("Book Page Number")]
        [Range(minimum: 100, maximum: 500)]
        [Required]
        public int Page { get; set; }


        [DisplayName("Book Price")]
        [Required]
        [Range(minimum: 100, maximum: 50000)]
        public decimal Price { get; set; }
    }
}
}
