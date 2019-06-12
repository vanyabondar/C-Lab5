using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5_1
{
    class OrderToProduct
    {
        static public int Insert(int OrderId, int ProductId, int Quanity)
        {

            SqlCommand command = new SqlCommand("INSERT INTO order_to_products values(@OrderToProductID,@OrderId,@ProductId,@Quanity);", ProjectConnection.conn);
            int id = Program.FoundID("order_to_products", "OrderToProductID");

            command.Parameters.AddWithValue("@OrderToProductID", id);
            command.Parameters.AddWithValue("@OrderId", OrderId);
            command.Parameters.AddWithValue("@ProductId", ProductId);
            command.Parameters.AddWithValue("@Quanity", Quanity);
            return command.ExecuteNonQuery();
        }

        static public int Update(int OrderToProductID, int OrderId, int ProductId, int Quanity)
        {

            SqlCommand command = new SqlCommand("UPDATE order_to_products SET OrderId = @OrderId, ProductId = @ProductId, Quanity = @Quanity,  WHERE OrderToProductID  = @OrderToProductID;", ProjectConnection.conn);

            command.Parameters.AddWithValue("@OrderToProductID", OrderToProductID);
            command.Parameters.AddWithValue("@OrderId", OrderId);
            command.Parameters.AddWithValue("@ProductId", ProductId);
            command.Parameters.AddWithValue("@Quanity", Quanity);

            return command.ExecuteNonQuery();
        }

        static public int Delete(int OrderToProductID)
        {

            SqlCommand command2 = new SqlCommand("DELETE FROM order_to_products WHERE OrderToProductID  = @OrderToProductID;", ProjectConnection.conn);

            command2.Parameters.AddWithValue("@OrderToProductID", OrderToProductID);
            return command2.ExecuteNonQuery();
        }

        static public void Select()
        {
            ProjectConnection.PrintSelect("SELECT * FROM order_to_products;");
        }
    }
}

