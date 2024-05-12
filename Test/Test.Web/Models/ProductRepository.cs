using Test.Web.Models;

namespace Test.Web.Models
{
    public class ProductRepository
    {
        // ramde tutmak için liste oluşturulması
        private static List<Product> _products = new List<Product>
        {
            new() { Id = 1, Name = "Acer", Price = 30,Stock = 0 },
            new() { Id = 2, Name = "Toshiba", Price = 30, Stock = 10 },
            new() { Id = 3, Name = "Asus", Price = 30, Stock = 3 },
            new() { Id = 4, Name = "MSI", Price = 30, Stock = 2 },
            new() { Id = 5, Name = "Apple", Price = 30, Stock = 1 }
        };

        // normal yol bunu siliyoruz

        //public List<Product> Products()
        //{
        //    return _products;
        //}



        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadır.");
            }
            _products.Remove(hasProduct);
        }

    
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id})'ye sahip ürün bulunmamaktadır.");
            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[index] = hasProduct;
        }


    }
}
