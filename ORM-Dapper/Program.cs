using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

//var repo = new DapperDepartmentRepo(conn);

//repo.InsertDepartment("Routers");

//var departments = repo.GetAllDepartments();

//foreach (var department in departments)
//{
//  Console.WriteLine($"{department.DepartmentID} | {department.Name}");
//}

var repo = new DapperProductRepo(conn);

repo.CreateProduct("Alienware m18 Gaming Laptop", 2999.00, 10 );

var products = repo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($" {product.ProductID} | {product.Name} | {product.Price} | {product.CategoryID} | {product.OnSale} | {product.StockLevel} ");
}
