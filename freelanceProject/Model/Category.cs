using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace freelanceProject.Model
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Product>? Products{ get; set; }

    }
}
