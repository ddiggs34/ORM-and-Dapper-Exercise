using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class DapperProductRepo : IProductRepo
    {

        private readonly IDbConnection _connection;
        public DapperProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @onSale, @stockLevel);",
                new {name, price, categoryID, onSale, stockLevel});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product> ("SELECT * FROM products;");
        }

        public void UpdateProductName(int productID, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID",
                new { newName, productID });
        }

        public void DeleteProduct(int productID) 
        {

            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID});
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID });
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID });


        }
    }
}
