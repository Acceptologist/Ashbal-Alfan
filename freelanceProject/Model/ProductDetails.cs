using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace freelanceProject.Model
{
    public class ProductDetails
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public int Price { get; set; }
        public int Amount { get; set; }


        [ForeignKey("Product")]
        public Guid Product_Id { get; set; }

        [JsonIgnore]
        public virtual Product? Product { get; set; }
    }
}
