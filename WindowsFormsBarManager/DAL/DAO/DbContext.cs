using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBarManager.DAL.DAO
{
    public class DbContext
    {
        private static DbContext instance;
        private string con = "Server=LAPCUAKHANHH\\MSSQLSERVER01;Database=BarManager;User Id=sa;Password=12345;Encrypt=False;TrustServerCertificate=True";

        private DbContext() { }
        public static DbContext Instance { get { if (instance == null) instance = new DbContext();return instance;} 
                                                private set => instance = value; }

        public DataTable ExcuteQuery(string query, object[] parameter=null)
        {
            DataTable dTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(con))
            {
            connection.Open();
            SqlCommand command=new SqlCommand(query, connection);
                if(parameter != null ) {
                    string[] pList=query.Split(' ');
                    int i = 0;
                    foreach (string item in pList)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dTable);
            connection.Close();
            }    
            return dTable;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] pList = query.Split(' ');
                    int i = 0;
                    foreach (string item in pList)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                 data=command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] pList = query.Split(' ');
                    int i = 0;
                    foreach (string item in pList)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
