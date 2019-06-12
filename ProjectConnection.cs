using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace lab5_1
{
    class ProjectConnection
    {
        //Статичне поле для зберігання зєднання
        public static SqlConnection conn = null;

        //Метод для виведення результатів SELECT-у
        public static void PrintSelect(string sql)
        {

            // отримання результатів sql запиту
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();
            // заповнення об'єкту данними sql результату
            adapter.Fill(dataSet);
            DataTable dt = dataSet.Tables[0];
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // вивід атрибутів таблиці результату
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write("{0, 20}", column.ColumnName);
                Console.Write(" ");
            }
            Console.WriteLine();

            // вивід вмісту результуючої таблиці
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                {
                    Console.Write("{0, 20}", cell);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


        }

        //Встановлення зєднання
        public void Connection_Now()
        {
            conn = new SqlConnection("Data Source=DESKTOP-HR9R1I1;Initial Catalog=PublishingHouse;Integrated Security=True");
            conn.Open();
        }
    }
}
