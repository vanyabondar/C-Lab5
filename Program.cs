using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5_1
{
    class Program
    {

        static public int FoundID(string table, string column)
        {
            string str = "SELECT MAX(" + column + ") FROM " + table + ";";

            SqlCommand command = new SqlCommand(str, ProjectConnection.conn);


            object countObj = command.ExecuteScalar(); 
            return  (countObj.ToString() == "") ? 1 : (int)countObj + 1;
        }

        static public void Ex1()
        {
            Console.WriteLine("Вивести імена працівників та департаменти в яких вони працюють:");
            ProjectConnection.PrintSelect(
                "SELECT FirstName, LastName, DepartmentName FROM employees " +
                "JOIN departments ON employees.DepartmentId = departments.DepartmentId;"
                );
        }
        static public void Ex2()
        {
            Console.WriteLine("Вивести імена працівників та департаменти в яких вони працюють:");
            ProjectConnection.PrintSelect(
                "SELECT Avg(Quanity) AS \"Average\" FROM order_to_products ;"
                );
        }
        static public void Ex3()
        {
            Console.WriteLine("Вивести типи продукції відсортовоні по вартості одного екземпляру:");
            ProjectConnection.PrintSelect(
                "SELECT ProductType, Cost FROM price_list " +
                "ORDER BY Cost;"
                );
        }
        static public void Ex4()
        {
            Console.WriteLine("Вивести типи продукції та їх підсумкову вартість для кожного замовлення:");
            ProjectConnection.PrintSelect(
                "SELECT OrderId, ProductType, Quanity*Cost AS \"Price\" FROM order_to_products " +
                "JOIN price_list ON order_to_products.ProductId = price_list.ProductId ;"
                );
        }
        static public void Ex5()
        {
            Console.WriteLine("Вивести сумарну вартість кожного замовлення:");
            ProjectConnection.PrintSelect(
                "SELECT OrderId, SUM(Quanity*Cost) AS \"Price\" FROM order_to_products " +
                "JOIN price_list ON order_to_products.ProductId = price_list.ProductId " +
                "GROUP BY OrderId "
                );
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ProjectConnection newConnection = new ProjectConnection();
            newConnection.Connection_Now();
            

            /*
            Department.Insert("The department of preparation of publishing originals");
            Department.Insert("Advertising department");
            Department.Insert("Department of printing");

            Employee.Insert("Ivanov", "Ivan", "Polygraphist", "Engineer Polygraphist", 3);
            Employee.Insert("Petrov", "Petro", "Managare", "Managare", 2);
            Employee.Insert("Sidorov", "Goat", "Cleaner", "None", 3);
            Employee.Insert("Konovalov", "Denis", "Editor in Chief", "Editor", 1);

            PrintingDevice.Insert("Laser Printers");
            PrintingDevice.Insert("Thermal Printers");

            DepartmentToDevice.Insert(3,1);
            DepartmentToDevice.Insert(3,2);
            
            Product.Insert("Book", 100, 2000, 20, 50);
            Product.Insert("Journal", 20, 2000, 15, 8);
            Product.Insert("Newspaper", 100, 2000, 5, 2);
            Product.Insert("Postcard", 100, 10000, 3, 1);

            Order.Insert("12345678912345678912", "14725836914725836914");
            Order.Insert("78945612378945612378", "14725836914725836914");

            OrderToProduct.Insert(1, 1, 200);
            OrderToProduct.Insert(1, 2, 200);
            OrderToProduct.Insert(2, 4, 5000);
            */

            /*SqlCommand comm = new SqlCommand();
            

            SqlCommand comm1 = new SqlCommand();
            comm1.Connection = ProjectConnection.conn;
            comm1.CommandText = "update orders set CustomerBankAccount = @CustomerBankAccount where OrderId = 1";
            comm1.Parameters.AddWithValue("CustomerBankAccount", "gigigigg");
            comm1.ExecuteNonQuery();
            */
            Ex1();
            Ex2();
            Ex3();
            Ex4();
            Ex5();

            Console.ReadKey();
            
        }
    }
}
