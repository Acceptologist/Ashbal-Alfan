using Final_Project.Models;
using freelanceProject.DTO;
using freelanceProject.Model;
using Microsoft.EntityFrameworkCore;

namespace freelanceProject.Repository
{
    public class ProductRepository :IProductRepository
    {
        EntityContext context;

        public ProductRepository(EntityContext context)
        {
            this.context=context;
        }
        public void Delete(Guid id)
        {
            Product product = GetById(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return context.Products.FirstOrDefault(d => d.Id == id);
        }

        public List<int> GetProductAmounts(Guid id)
        {
            return context.ProductDetails.Where(pd => pd.Product_Id==id).Select(pd => pd.Amount).Distinct().ToList();
        }

        public int GetProductPriceByType(Guid id, string type)
        {
            return context.ProductDetails.Where(pd => pd.Product_Id==id && pd.Type==type).Select(pd => pd.Price).First();
        }

        public int GetProductPriceByTypeAndAmount(Guid id, string type, int amount)
        {
            return context.ProductDetails.Where(pd => pd.Product_Id==id && pd.Type==type &&  pd.Amount==amount)
                .Select(pd => pd.Price).First();
        }

        public List<ProductDetails> GetProductPricePlan(Guid id)
        {
            return this.context.Products.Include(p=>p.ProductDetails).FirstOrDefault(p => p.Id==id).ProductDetails;
        }

        public List<Product> GetProductsByCategoryId(Guid id)
        {
           return  context.Products.Where(product => product.Category_Id==id).ToList();
        }

        public List<Product> GetProductsByCategoryName(string name)
        {
            return context.Products.Where(product => product.Category_Name==name).ToList();
        }

        public List<string> GetProductTypes(Guid id)
        {
            return context.ProductDetails.Where(pd => pd.Product_Id==id).Select(pd => pd.Type).Distinct().ToList();
        }

        public void Insert(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }

        public void Update(Guid id, Product product)
        {
            Product newProduct = this.context.Products.Include(p=>p.ProductDetails).FirstOrDefault(d => d.Id == id);


            newProduct.Title = product.Title;
            newProduct.Image1 = product.Image1;
            newProduct.Image2 = product.Image2;
            newProduct.Image3 = product.Image3;
            newProduct.Image4 = product.Image4;
            newProduct.Image5 = product.Image5;
            newProduct.maxPrice= product.maxPrice;
            newProduct.minPrice= product.minPrice;
            newProduct.Description = product.Description;
            newProduct.SKU = product.SKU;
            newProduct.Availabilty = product.Availabilty;
            newProduct.Category_Id = product.Category_Id;
            newProduct.Category_Name = product.Category_Name;
            newProduct.isAmountExist= product.isAmountExist;
            newProduct.isTypeExist= product.isTypeExist;
            newProduct.ProductDetails.Clear();
            newProduct.ProductDetails=product.ProductDetails;


            context.SaveChanges();
        }

        public void UpdateProductPricePlan(Guid id,List<ProductDetails> productDetails)
        {
            foreach (ProductDetails newProductDetails in productDetails) {
                var oldProductDetails = this.context.ProductDetails.FirstOrDefault(p=>p.Id==newProductDetails.Id);
                oldProductDetails.Price= newProductDetails.Price;
            }

            context.SaveChanges();
        }
        public int Count()
        {
            return this.context.Products.Count();
        }

        public List<Product> GetAllPagination(int page, int pageSize)
        {
            int skip = page*pageSize;
            return this.context.Products.Skip(skip).Take(pageSize).ToList();
        }

    }
}
