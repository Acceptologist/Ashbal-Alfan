using System.ComponentModel.DataAnnotations;

namespace freelanceProject.Model
{
    public class HomeInfo
    {
        public HomeInfo() { 
            this.ClientHosting=0;
            this.Design=0;
            this.WorkHours="";
            this.Email="";
            this.Clients=0;
            this.Experience=0;
            this.Phone="";
            this.Headquarters="";
            this.Location="";
        }
        [Key]
        public int Id { get; set; }
        public int Clients { get; set; }
        public int Design { get; set; }
        public int ClientHosting { get; set; }

        public int Experience { get; set; }

        public string Headquarters { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string WorkHours { get; set; }

        public string Location { get; set; }


    }
}
