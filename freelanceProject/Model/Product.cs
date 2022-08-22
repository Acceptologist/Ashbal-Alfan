using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace freelanceProject.Model
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }

        public string Description { get; set; }

        public double maxPrice { get; set; }
        public double minPrice { get; set; }

        public string SKU { get; set; }
        public bool isTypeExist { get; set; }
        public bool isAmountExist { get; set; }

        public Boolean Availabilty { get; set; }

        [ForeignKey("Category")]
        public Guid Category_Id { get; set; }

        public string Category_Name { get; set; }

        [JsonIgnore]
        public virtual Category? Category { get; set; }

        public virtual List<ProductDetails>? ProductDetails { get; set; }

    }
}
