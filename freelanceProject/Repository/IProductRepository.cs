using freelanceProject.DTO;
using freelanceProject.Model;

namespace freelanceProject.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        public List<Product> GetProductsByCategoryId(Guid id);
        public List<Product> GetProductsByCategoryName(string name);

        public List<string> GetProductTypes(Guid id);

        public List<int> GetProductAmounts(Guid id);

        public int GetProductPriceByType(Guid id, string type);

        public int GetProductPriceByTypeAndAmount(Guid id, string type,int amount);

        public List<ProductDetails> GetProductPricePlan(Guid id);

        public void UpdateProductPricePlan(Guid id, List<ProductDetails> productDetails);


    }
}
