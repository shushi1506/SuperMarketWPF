using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;
using WPFSuperMarket.Providers;

namespace WPFSuperMarket.Controllers
{
    public class ProductController
    {
        private ProductProvider _productProvider
        {
            get
            {
                return new ProductProvider();
            }
        }

        public ProductController()
        {
            //_productProvider = new ProductProvider();
        }

        public List<ProductTableModel> ListProductsTableModel
        {
            get
            {
                return ProductTableModel.ToListByListProduct(_productProvider.getAll());
            }
        }

        public List<Product> GetAll()
        {
            return _productProvider.getAll();
        }

        public Product GetById(int Id)
        {
            return _productProvider.getById(Id);
        }
        public Product GetByBarCode(string Id)
        {
            return _productProvider.getByBarCode(Id);
        }
        public bool Add(Product product)
        {
            bool key = _productProvider.Insert(product);
            if (!key) return key;

            try
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(App.BaseImageDirectory + "Product\\" + product.Picture);

                System.IO.File.WriteAllBytes(
                    App.BaseImageDirectory + "Product\\" + product.Id + ".jpg",
                    (byte[])imageBytes);

                product.Picture = product.Id + ".jpg";
                _productProvider.Update(product);
            }
            catch (Exception)
            {

            }

            return key;
        }

        public bool Update(Product product)
        {
            return _productProvider.Update(product);
        }

        public bool Delete(int Id)
        {
            return _productProvider.Delete(Id);
        }

        public List<ProductTableModel> GetListTableModelBySearch(string search)
        {
            return ProductTableModel.ToListByListProduct(_productProvider.GetBySearch(search));
        }

        public bool Pause(int Id)
        {
            return _productProvider.Pause(Id);
        }
    }
}
