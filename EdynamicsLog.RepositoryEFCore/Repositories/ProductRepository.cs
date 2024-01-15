using EdynamicsLog.DTOs.Product;
using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.Entities.POCOs;
using EdynamicsLog.RepositoryEFCore.DataContext;

namespace EdynamicsLog.RepositoryEFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly EdynamicsLogProductsContext Context;

        public ProductRepository(EdynamicsLogProductsContext context) => Context = context;

        public void CreateProduct(Product product)
        {
            Context.Add(product);
        }

        public void DeleteProduct(string slugTenatOrganization, int idProduct)
        {
            var productToDelete = Context.Products.FirstOrDefault(p =>
                p.Id == idProduct && p.SlugTenatOrganization == slugTenatOrganization);

            if (productToDelete == null)
            {
                throw new InvalidOperationException("El producto no se encontró");
            }

            Context.Products.Remove(productToDelete);
            Context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts(string SlugTenatOrganization)
        {
            return Context.Products.Where(p => p.SlugTenatOrganization == SlugTenatOrganization).ToList();
        }

        public Product GetProductById(int id, string slugTenatOrganization)
        {
            return Context.Products .FirstOrDefault(p => p.Id == id && p.SlugTenatOrganization == slugTenatOrganization);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = Context.Products.FirstOrDefault(p => p.Id == product.Id && p.SlugTenatOrganization == product.SlugTenatOrganization);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Duration = product.Duration;

                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("El producto no se encontró");
            }
        }
    }
}
