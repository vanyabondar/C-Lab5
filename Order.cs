using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5_1
{
    class Order
    {
        static public int Insert(string CustomerBankAccount, string ExecutiveBankAccount)
        {

            SqlCommand command = new SqlCommand("INSERT INTO orders values(@OrderId,@CustomerBankAccount,@ExecutiveBankAccount);", ProjectConnection.conn);
            int id = Program.FoundID("orders", "OrderId");

            command.Parameters.AddWithValue("@OrderId", id);
            command.Parameters.AddWithValue("@CustomerBankAccount", CustomerBankAccount);
            command.Parameters.AddWithValue("@ExecutiveBankAccount", ExecutiveBankAccount);
            return command.ExecuteNonQuery();
        }

        static public int Update(int OrderId, string CustomerBankAccount, string ExecutiveBankAccount)
        {

            SqlCommand command = new SqlCommand("UPDATE orders SET CustomerBankAccount = @CustomerBankAccount, ExecutiveBankAccount = @ExecutiveBankAccount WHERE OrderId  = @OrderId;", ProjectConnection.conn);

            command.Parameters.AddWithValue("@OrderId", OrderId);
            command.Parameters.AddWithValue("@CustomerBankAccount", CustomerBankAccount);
            command.Parameters.AddWithValue("@ExecutiveBankAccount", ExecutiveBankAccount);

            return command.ExecuteNonQuery();
        }

        static public int Delete(int OrderId)
        {

            SqlCommand command2 = new SqlCommand("DELETE FROM orders WHERE OrderId  = @OrderId;", ProjectConnection.conn);

            command2.Parameters.AddWithValue("@OrderId", OrderId);
            return command2.ExecuteNonQuery();
        }

        static public void Select()
        {
            ProjectConnection.PrintSelect("SELECT * FROM orders;");
        }
    }
}

