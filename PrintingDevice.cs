using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5_1
{
    class PrintingDevice
    {
        static public int Insert(string PrintingDeviceName)
        {

            SqlCommand command = new SqlCommand("INSERT INTO printing_devices values(@PrintingDeviceId,@PrintingDeviceName);", ProjectConnection.conn);
            int id = Program.FoundID("printing_devices", "PrintingDeviceId");

            command.Parameters.AddWithValue("@PrintingDeviceId", id);
            command.Parameters.AddWithValue("@PrintingDeviceName", PrintingDeviceName);
            return command.ExecuteNonQuery();
        }

        static public int Update(int PrintingDeviceId, string PrintingDeviceName)
        {

            SqlCommand command = new SqlCommand("UPDATE printing_devices SET PrintingDeviceName = @PrintingDeviceName WHERE PrintingDeviceId  = @PrintingDeviceId; ", ProjectConnection.conn);

            command.Parameters.AddWithValue("@PrintingDeviceId", PrintingDeviceId);
            command.Parameters.AddWithValue("@PrintingDeviceName", PrintingDeviceName);
            return command.ExecuteNonQuery();
        }

        static public int Delete(int PrintingDeviceId)
        {
            SqlCommand command0 = new SqlCommand("DELETE FROM department_to_device WHERE PrintingDeviceId  = @PrintingDeviceId;", ProjectConnection.conn);

            command0.Parameters.AddWithValue("@PrintingDeviceId", PrintingDeviceId);

            command0.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("DELETE FROM printing_devices WHERE PrintingDeviceId  = @PrintingDeviceId;", ProjectConnection.conn);

            command2.Parameters.AddWithValue("@PrintingDeviceId", PrintingDeviceId);
            return command2.ExecuteNonQuery();
        }

        static public void Select()
        {
            ProjectConnection.PrintSelect("SELECT * FROM printing_devices;");
        }
    }
}
