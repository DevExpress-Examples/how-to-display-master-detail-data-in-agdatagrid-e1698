using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace MasterDetail {

    public class Products {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
    }

    [XmlRoot("NewDataSet")]
    public class ProductsData : List<Products> {
        public static ProductsData DataSource {
            get {
                XmlSerializer s = new XmlSerializer(typeof(ProductsData));
                System.IO.Stream assemblyGetManifestResourceStream = typeof(ProductsData).Assembly.GetManifestResourceStream(typeof(ProductsData).Namespace + ".Data.Products.xml");
                return (ProductsData)s.Deserialize(assemblyGetManifestResourceStream);
            }
        }

        public object GetProductsByCategory(int categoryID) {
            return from product in this
                   where product.CategoryID == categoryID
                   select product;
        }
    }


    public class Categories {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }        
        public object Products { get; set; }        
    }

    [XmlRoot("NorthwindDataSet")]
    public class CategoriesData : List<Categories> {
        private static List<Categories> ReadCategories() {
            XmlSerializer s = new XmlSerializer(typeof(CategoriesData));
            System.IO.Stream assemblyGetManifestResourceStream = typeof(CategoriesData).Assembly.GetManifestResourceStream(typeof(CategoriesData).Namespace + ".Data.Categories.xml");
            return (List<Categories>)s.Deserialize(assemblyGetManifestResourceStream);
        }
        public static List<Categories> DataSource {
            get {
                List<Categories> categories = ReadCategories();
                ProductsData products = ProductsData.DataSource;
                foreach (Categories category in categories)
                    category.Products = products.GetProductsByCategory(category.CategoryID);
                return categories;
            }
        }
    }



}
