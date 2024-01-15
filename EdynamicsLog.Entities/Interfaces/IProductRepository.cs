using EdynamicsLog.Entities.POCOs;

namespace EdynamicsLog.Entities.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(string slugTenatOrganization, int idProduct);

        IEnumerable<Product> GetAllProducts(string SlugTenatOrganization);

        Product GetProductById(int id, string slugTenatOrganization);
    }
}
