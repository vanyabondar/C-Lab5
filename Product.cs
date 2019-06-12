using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5_1
{
    class Product
    {
        static public int Insert(string ProductType, int MinQuanity, int MaxQuanity, int Deadline, int Cost)
        {

            SqlCommand command = new SqlCommand("INSERT INTO price_list values(@ProductId,@ProductType,@MinQuanity,@MaxQuanity,@Deadline,@Cost);", ProjectConnection.conn);
            int id = Program.FoundID("price_list", "ProductId");

            command.Parameters.AddWithValue("@ProductId", id);
            command.Parameters.AddWithValue("@ProductType", ProductType);
            command.Parameters.AddWithValue("@MinQuanity", MinQuanity);
            command.Parameters.AddWithValue("@MaxQuanity", MaxQuanity);
            command.Parameters.AddWithValue("@Deadline", Deadline);
            command.Parameters.AddWithValue("@Cost", Cost);
            return command.ExecuteNonQuery();
        }

        static public int Update(int ProductId, string ProductType, int MinQuanity, int MaxQuanity, int Deadline, int Cost)
        {

            SqlCommand command = new SqlCommand("UPDATE price_list SET ProductType = @ProductType,MinQuanity = @MinQuanity,MaxQuanity = @MaxQuanity,Deadline = @Deadline,Cost = @Cost WHERE ProductId  = @ProductId;", ProjectConnection.conn);

            command.Parameters.AddWithValue("@ProductId", ProductId);
            command.Parameters.AddWithValue("@ProductType", ProductType);
            command.Parameters.AddWithValue("@MinQuanity", MinQuanity);
            command.Parameters.AddWithValue("@MaxQuanity", MaxQuanity);
            command.Parameters.AddWithValue("@Deadline", Deadline);
            command.Parameters.AddWithValue("@Cost", Cost);
            return command.ExecuteNonQuery();
        }

        static public int Delete(int ProductId)
        {

            SqlCommand command = new SqlCommand("DELETE FROM price_list WHERE ProductId  = @ProductId;", ProjectConnection.conn);

            command.Parameters.AddWithValue("@ProductId", ProductId);
            return command.ExecuteNonQuery();
        }

        static public void Select()
        {
            ProjectConnection.PrintSelect("SELECT * FROM price_list;");
        }
    }
}
