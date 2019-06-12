using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace lab5_1
{
    class Employee
    {

        static public int Insert(string FirstName, string LastName, string Position, string Speciality, int DepartmentId)
        {

            SqlCommand command = new SqlCommand("INSERT INTO employees values(@EmployeeId,@FirstName,@LastName,@Position,@Speciality,@DepartmentId);", ProjectConnection.conn);
            int id = Program.FoundID("employees", "EmployeeId");

            command.Parameters.AddWithValue("@EmployeeId", id);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Position", Position);
            command.Parameters.AddWithValue("@Speciality", Speciality);
            command.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            return command.ExecuteNonQuery();
        }

        static public int Update(int EmployeeId, string FirstName, string LastName, string Position, string Speciality, int DepartmentId)
        {

            SqlCommand command = new SqlCommand("UPDATE employees SET FirstName = @FirstName,LastName = @LastName,Position = @Position,Speciality = @Speciality,DepartmentId = @DepartmentId WHERE EmployeeId  = @EmployeeId;", ProjectConnection.conn);
            
            command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Position", Position);
            command.Parameters.AddWithValue("@Speciality", Speciality);
            command.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            return command.ExecuteNonQuery();
        }

        static public int Delete(int EmployeeId)
        {

            SqlCommand command = new SqlCommand("DELETE FROM employees WHERE EmployeeId  = @EmployeeId;", ProjectConnection.conn);
 
            command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            return command.ExecuteNonQuery();
        }

        static public void Select()
        {
            ProjectConnection.PrintSelect("SELECT * FROM employees;");
        }

    }
}
