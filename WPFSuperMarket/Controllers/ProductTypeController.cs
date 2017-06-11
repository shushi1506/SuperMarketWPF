using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSuperMarket.Models;
using WPFSuperMarket.Providers;

namespace WPFSuperMarket.Controllers
{
    public class ProductTypeController
    {
        private ProductTypeProvider _productTypeProvider
        {
            get
            {
                return new ProductTypeProvider();
            }
        }

        public ProductTypeController()
        {
            //_productTypeProvider = new ProductTypeProvider();
        }

        public List<ProductTypeTableModel> ListProductTypesTableModel
        {
            get
            {
                return ProductTypeTableModel.ToListByListProductType(_productTypeProvider.getAll());
            }
        }

        public ProductType GetProductTypeById(int Id)
        {
            return _productTypeProvider.getById(Id);
        }

        public List<ProductType> GetAllProductTypes()
        {
            return _productTypeProvider.getAll();
        }

        public bool Add(ProductType productType)
        {
            return _productTypeProvider.Insert(productType);
        }

        public bool Update(ProductType productType)
        {
            return _productTypeProvider.Update(productType);
        }

        public bool Delete(int Id)
        {
            return _productTypeProvider.Delete(Id);
        }

        public List<ProductTypeTableModel> GetListTableModelBySearch(string search)
        {
            return ProductTypeTableModel.ToListByListProductType(
                _productTypeProvider.Search(search));
        }
    }
}
