using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5_1
{
    class Department
    {
        //метод вставки запису в таблицю
        static public int Insert(string DepartmentName)
        {

            SqlCommand command = new SqlCommand("INSERT INTO departments values(@DepartmentId,@DepartmentName);", ProjectConnection.conn);
            int id = Program.FoundID("departments", "DepartmentId");

            command.Parameters.AddWithValue("@DepartmentId", id);
            command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            return command.ExecuteNonQuery();
        }
        //Метод оновлення засисів
        static public int Update(int DepartmentId, string DepartmentName)
        {

            SqlCommand command = new SqlCommand("UPDATE departments SET DepartmentName = @DepartmentName WHERE DepartmentId  = @DepartmentId; ", ProjectConnection.conn);

            command.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            return command.ExecuteNonQuery();
        }
        //Метод каскадного видалення  засисів

        static public int Delete(int DepartmentId)
        {
            SqlCommand command0 = new SqlCommand("DELETE FROM department_to_device WHERE DepartmentId  = @DepartmentId;", ProjectConnection.conn);

            command0.Parameters.AddWithValue("@DepartmentId", DepartmentId);

            command0.ExecuteNonQuery();

            SqlCommand command1 = new SqlCommand("DELETE FROM employees WHERE DepartmentId  = @DepartmentId;", ProjectConnection.conn);

            command1.Parameters.AddWithValue("@DepartmentId", DepartmentId);

            command1.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("DELETE FROM departments WHERE DepartmentId  = @DepartmentId;", ProjectConnection.conn);

            command2.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            return command2.ExecuteNonQuery();
        }

        static public void Select()
        {
            ProjectConnection.PrintSelect("SELECT * FROM departments;");
        }
    }
}
