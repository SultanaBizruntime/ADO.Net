using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ADO.Net
{
    
        class Program
        {
          
            public void CreateTable()
            {
                SqlConnection con = null;
                try
                {
                   
                // Creating Connection  
                    con = new SqlConnection(@"Data Source=DESKTOP-KISINUE\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");
                    
                // writing sql query  
                    SqlCommand cm = new SqlCommand("create table Employee1(id int not null, name varchar(100), email varchar(50))", con);  
                   
                // Opening Connection  
                   con.Open();
                    // Executing the SQL query  
                    //cm.ExecuteNonQuery();
                    // Displaying a message  
                    Console.WriteLine("Table created Successfully");

                SqlCommand cm1 = new SqlCommand("insert into Employee1(id, name, email) values(1,'sulthana','sulthana@gmail.com')", con);

                SqlCommand cm2 = new SqlCommand("Select * from Employee1", con);
                cm.ExecuteNonQuery();
                cm1.ExecuteNonQuery();

                SqlDataReader sdr = cm2.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]); // Displaying Record  
                }


                cm2.ExecuteNonQuery();
            }
            catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong." + e);
                }
                // Closing the connection  
                finally
                {
                    con.Close();
                }
            }

            static void Main(string[] args)
            {
                new Program().CreateTable();
                Console.Read();
            }
    }
}

