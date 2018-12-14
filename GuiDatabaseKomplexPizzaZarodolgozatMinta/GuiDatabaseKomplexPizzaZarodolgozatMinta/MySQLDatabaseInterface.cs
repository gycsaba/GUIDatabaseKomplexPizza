using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
//Console alkalmazás esetén
//To add reference in c# program right click in your project folders shown in 
//solution explorer on add references-> .Net -> select System.Windows.Forms. 
using System.Windows.Forms;

namespace ConnectToMysqlDatabase
{
    class MySQLDatabaseInterface
    {
        private MySqlConnection connection;
        private MySqlDataAdapter dataAdapter;
        private MySqlCommandBuilder commandBuilder;

        private string server;
        private string database;
        private string username;
        private string password;
        private string port;
        private string ssl_mode;

        // hiba MYSQL utasításokban
        private string errorMessage;

        // hiba megjelenjen-e a program futása közben
        bool errorToUserInterface;
        // hiba grafikus interfacen jelenjen meg vagy nem (ha nem akkor konzolon)
        bool errorToGraphicalUserInterface;
        


        public MySQLDatabaseInterface()
        {
            server = string.Empty;
            database = string.Empty;
            username = string.Empty;
            password = string.Empty;
            port = string.Empty;
            ssl_mode = "none";

            errorMessage = string.Empty;

            errorToUserInterface = false;
            errorToGraphicalUserInterface = false;
        }

        public void setErrorToUserInterface(bool etui)
        {
            errorToUserInterface=etui;
        }
        public void setErrorToGraphicalUserInterface(bool etgui)
        {
            errorToGraphicalUserInterface=etgui;
        }
       
        private void writeErrorToConsoleUserInterface()
        {
            Console.WriteLine("Hiba az adatbázis művelet közben:");
            Console.WriteLine(errorMessage);
        }

        private void writeErrorToGgrapichalUserInterface()
        {
            MessageBox.Show(
                "Adatábzis hiba: "+errorMessage,                
                "Adatbázis hiba...",
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error
           );
        }

        private void setErrorDataAndShow(string message)
        {
            errorMessage = message;
            if (errorToUserInterface)
            {
                if (errorToGraphicalUserInterface)
                    writeErrorToGgrapichalUserInterface();
                else
                    writeErrorToConsoleUserInterface();
            }

        }

        private bool isEmptyOneParameter()
        {
            bool answer = false;
            if (server == string.Empty)
                answer = true;
            else if (database == string.Empty)
                answer = true;
            else if (username == string.Empty)
                answer = true;
           /* else if (password == string.Empty)
                answer = true;*/
            if (answer == true)
                setErrorDataAndShow("Valamelyik kapcsolati paraméter üres");
            return answer;
        }
        private bool isConnectionExsist()
        {
            if (connection == null)
            {
                setErrorDataAndShow("A kapcsolat nem létezik.");
                return false;
            }
            else
                return true;
        }

        public void setConnectionServerData(string server,string database, string port, string ssl_mode="none")
        {
            this.server=server;
            this.database=database;
            this.port = port;
            this.ssl_mode = ssl_mode;
        }
        public void setConnectionUserData(string username,string password)
        {
            this.username=username;
            this.password=password;
        }
        public bool makeConnectionToDatabase()
        {
            if (isEmptyOneParameter())
            {
                connection = null;
                return false;
            }
            string connectionString = "SERVER=" + server + ";"
                                    + "DATABASE=" + database + ";"
                                    + "UID=" + username + ";"
                                    + "PASSWORD=" + password + ";"
                                    + "PORT=" + port + ";"
                                    + "SSLMode  ="+ssl_mode+";";
            try
            {
                connection = new MySqlConnection(connectionString);
                return true;
            }
            catch (MySqlException e)
            {
                setErrorDataAndShow("Adatbázis kapcsolat nem jött létre.");
            }
            return true;
            
        }

        public bool open()
        {
            if (!isConnectionExsist())
                return false;
            else
            {
                //ha már nyitva van a kapcsolat ne nyissa meg mégegyszer
                if ((connection != null) && (connection.State == ConnectionState.Open))
                    return true;
                else
                {
                    try
                    {
                        connection.Open();
                        return true;
                    }
                    catch (MySqlException me)
                    {
                        //http://dev.mysql.com/doc/refman/5.7/en/error-messages-server.html
                        switch (me.Number)
                        {
                            case 0:
                                    //Cannot connect to server.  Contact administrator"
                                    setErrorDataAndShow("Adatbázis kapcsolat nem jött létre."+me.Message);
                                break;
                            case 1045:
                                    //Invalid username/password, please try again"
                                    setErrorDataAndShow("A megadott jelszó vagy felhasználónév nem megfelelő.");     
                                break;
                            case 1042:
                                    //Message: Can't get hostname for your address 
                                    setErrorDataAndShow("A megadott host elérhetetlen.");
                                break;
                            default:
                                setErrorDataAndShow("Adatbázis kapcsolat nem jött létre.\n"+
                                                    me.Message/*+me.Number*/
                                                    );
                                break;                            
                        }
                        connection = null;
                        return false;
                    }
                }
            }          
        }
        public bool close()
        {
            if (!isConnectionExsist())
                return false;
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                setErrorDataAndShow("Adatbázis bezárás hiba.\n" +
                                                    e.Message/*+me.Number*/
                                                    );
                return false;
            }
        }
        public bool isExecutableQuery(string query)
        {
            if (query == string.Empty)
            {
                return false;
            }
            if (!isConnectionExsist())
            {
                return false;
            }
            return true;
        }

         public string getOneField(string query)
        //example query: SELECT username FROM user + "LIMIT 1"
        {
            query += " LIMIT 1";
            string result = string.Empty;
            if (!isConnectionExsist())
                return string.Empty;
            if (connection.State != ConnectionState.Open)
            {
                setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva. Lekérdezést nem lehet végrehajtani.\n");
                return result;
            }
            if (!isExecutableQuery(query))
            {
                return string.Empty;
            }
            MySqlDataReader dataReader = null;
            try
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();
                //Read onde row
                dataReader.Read();
                result = dataReader[0].ToString();
                
            }
            catch (MySqlException me)
            {
                setErrorDataAndShow("Adatbázis lekérdezés hiba.\n" +
                                                    me.Message/*+me.Number*/
                                                    );
            }
            finally
            {
                if (dataReader != null)
                {
                    //close Data Reader
                    dataReader.Close();
                }
            }
            //return list to be displayed
            return result;
        }

        public List<string> getOneFieldToList(string query)
        //example query: SELECT orszag FROM orszagok
        {
            List<string> list = new List<string>();
            if (!isConnectionExsist())
                return list;
            if (connection.State != ConnectionState.Open)
            {
                setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva. Lekérdezést nem lehet végrehajtani.\n");
                return list;
            }
            if (!isExecutableQuery(query))
            {
                return list;
            }
            MySqlDataReader dataReader = null;
            try
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader[0] + "");
                }
            }
            catch (MySqlException me)
            {
                setErrorDataAndShow("Adatbázis lekérdezés hiba.\n" +
                                                    me.Message/*+me.Number*/
                                                    );
            }
            finally
            {
                if (dataReader != null)
                {
                    //close Data Reader
                    dataReader.Close();
                }
            }
            //return list to be displayed
            return list;
        }


        public DataTable getToDataTable(string query)
        //example query: SELECT orszag,fovaros,gdp FROM orszagok WHERE foldr_hely=\"Nyugat-Európa\"
        {
            DataTable dt = new DataTable();
            if (!isConnectionExsist())
                return dt;
            if (connection.State != ConnectionState.Open)
            {
                setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva. Lekérdezést nem lehet végrehajtani.\n");
                return dt;
            }
            // using System.Data;
            if (!isExecutableQuery(query))
            {
                return dt;
            }
            MySqlCommand cmd;
            try
            {
                cmd = new MySqlCommand(query, connection);
                if (cmd == null)
                    return dt;
                dataAdapter = new MySqlDataAdapter(cmd);
                commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dt);
                
            }
            catch (MySqlException me)
            {
                setErrorDataAndShow("Adatbázis lekérdezés hiba.\n" +
                                                    me.Message/*+me.Number*/
                                                    );
            }
            finally
            {            
            }
            return dt;
        }
        public void executeDMQuery(string query)
        //example query: UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'
        //example query: INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')
        //example query: DELETE FROM tableinfo WHERE name='John Smith'
        {
               if (!isConnectionExsist())
                    return ;
                if (connection.State != ConnectionState.Open)
                {
                    setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva. Lekérdezést nem lehet végrehajtani.\n");
                    return;
                }
            if (!isExecutableQuery(query))
               {
                   return;
               }
               MySqlCommand cmd;
               try
               {
                   cmd=new MySqlCommand(query, connection);
                   //Execute command
                   cmd.ExecuteNonQuery();  
               }
               catch (MySqlException me)
               {
                   setErrorDataAndShow("Adatbázis módosítás hiba.\n" +
                                                    me.Message/*+me.Number*/
                                                    );
               }
               finally
               {
               }
        }
        public string executeScalarQuery(string query)
        //example query: SELECT Count(*) FROM table
        {
            string scalar = string.Empty;
            if (!isConnectionExsist())
                return string.Empty;
            if (connection.State!= ConnectionState.Open)
            {
                setErrorDataAndShow("Adatbázis kapcsolat nincs megnyitva. Lekérdezést nem lehet végrehajtani.\n");
                return scalar;
            }
            if (!isExecutableQuery(query))
            {
                return scalar;
            }

            MySqlCommand cmd;
            try
            {
                cmd = new MySqlCommand(query, connection);
                //Execute command
                scalar =cmd.ExecuteScalar().ToString();
            }
            catch (MySqlException me)
            {
                setErrorDataAndShow("Adatbázis lekérdezés hiba.\n" +
                                                    me.Message/*+me.Number*/
                                                    );
            }
            finally
            {
            }
            return scalar;
        }
        public void updateChangesInTable(DataTable dt)
        {
            try
            {
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                dataAdapter.Update(dt);
            }
            catch (MySqlException me)
            {
                setErrorDataAndShow("Adatbázis frissítési hiba.\n" +
                                                    me.Message/*+me.Number*/
                                                    );
            }
            catch (Exception e)
            {
                setErrorDataAndShow("Adatbázis frissítési hiba.\n" +
                                                    e.Message/*+me.Number*/
                                                    );
            }
            finally
            {
            }
        }

    }
}
