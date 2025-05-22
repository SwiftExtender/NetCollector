//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace NetFighter.DataServices
//{
//    public class SimpleDataService
//    {
//        private readonly IProductRepository _productRepository;
//        public ProductService(IProductRepository productRepository)
//        {
//            _productRepository = productRepository;
//        }

//        public async Task<List<Product>> GetFeaturedProductsAsync()
//        {
//            // Retrieve data via DAL
//            var allProducts = await _productRepository.GetAllProductsAsync();
//            // Apply business logic (e.g., filter featured products)
//            return allProducts.Where(p => p.IsFeatured).ToList();
//        }
//    }
//}
