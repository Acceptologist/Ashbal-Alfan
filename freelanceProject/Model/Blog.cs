using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace freelanceProject.Model
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public  string Image { get; set; }
        public DateTime CreationDate { get; set; }


    }
}
