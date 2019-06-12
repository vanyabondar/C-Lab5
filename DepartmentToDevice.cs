using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5_1
{
    class DepartmentToDevice
    {
        static public int Insert(int DepartmentId, int PrintingDeviceId)
        {

            SqlCommand command = new SqlCommand("INSERT INTO department_to_device values(@DepartmentToDeviceId,@DepartmentId,@PrintingDeviceId);", ProjectConnection.conn);
            int id = Program.FoundID("department_to_device", "DepartmentToDeviceId");

            command.Parameters.AddWithValue("@DepartmentToDeviceId", id);
            command.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            command.Parameters.AddWithValue("@PrintingDeviceId", PrintingDeviceId);
            return command.ExecuteNonQuery();
        }

        static public int Update(int DepartmentToDeviceId, int DepartmentId, int PrintingDeviceId)
        {

            SqlCommand command = new SqlCommand("UPDATE department_to_device SET DepartmentId = @DepartmentId, PrintingDeviceId = @PrintingDeviceId WHERE DepartmentToDeviceId  = @DepartmentToDeviceId;", ProjectConnection.conn);

            command.Parameters.AddWithValue("@DepartmentToDeviceId", DepartmentToDeviceId);
            command.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            command.Parameters.AddWithValue("@PrintingDeviceId", PrintingDeviceId);

            return command.ExecuteNonQuery();
        }

        static public int Delete(int DepartmentToDeviceId)
        {

            SqlCommand command2 = new SqlCommand("DELETE FROM department_to_device WHERE DepartmentToDeviceId  = @DepartmentToDeviceId;", ProjectConnection.conn);

            command2.Parameters.AddWithValue("@DepartmentToDeviceId", DepartmentToDeviceId);
            return command2.ExecuteNonQuery();
        }

        static public void Select()
        {
            ProjectConnection.PrintSelect("SELECT * FROM department_to_device;");
        }
    }
}
