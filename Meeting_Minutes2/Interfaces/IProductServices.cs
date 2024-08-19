using Meeting_Minutes2.Models;

namespace Meeting_Minutes2.Interfaces
{
    public interface IProductServices
    {
        public IEnumerable<ProductService> GetProductServiceList();

        public ProductService GetProductServiceById(int? id);

        public void CreateProductService(ProductService proService);

        public void UpdateProductService(ProductService proService);

        public void DeleteProductService(int? id);

    }
}
