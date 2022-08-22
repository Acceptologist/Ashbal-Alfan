namespace freelanceProject.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }

        public double maxPrice { get; set; }
        public double minPrice { get; set; }
        public bool isTypeExist { get; set; }
        public bool isAmountExist { get; set; }

    }
}
