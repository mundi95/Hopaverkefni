using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//Til að hægt sé að tengjast.
using System.Windows.Forms;
using System.Data;
/* Sveinn Máni Jónsson
 * Kristmundur Ari
 * 23.11.2016
 * Lokaverkefni
 */

namespace lokaverk_SK
{
    class Gagnagrunnur
    {
        //Server: Segir til um hvar severinn er hýstur, hjá okkur er það localhost.
        private string server;
        //Database: Nafnið á gagnagrunninum sem verið er að nota.
        private string database;
        // uid:er MySQL notendanafn
        private string uid;
        // Password: er MySQL lykilorðið
        private string password;
        //Tengistrengur: contains the connection string to connect to the database
        //and will be assinged to the connection variable.
        string tengistrengur = null;
        //Fyrirspyurn: inniheldur viðeigandi fyrirspurn hverju sinni
        string fyrirspurn = null;

        MySqlConnection sqltenging; //Þetta er notað til þess að opna tengingu við gagnagrunn
        MySqlCommand nySQLskipun;   //Þetta er notað til þess að framkvæma SQL fyrirspurnina
        MySqlDataReader sqllesari = null; //Lesari sem getur lesið úr SQL gagnagrunninum.

        /*Þessi aðferð tengir notanda við gagnagrunninn,
         * Þannig að þið breytið viðeigandi upplýsingum sem á við*/
        public void TengingVidGagnagrunn()
        {
            server = "tsuts.tskoli.is";
            database = "2512982709_lokaverkefni";
            uid = "2512982709";
            password = "mypassword";

            tengistrengur = "server=" + server + ";userid=" + uid + ";password=" + password + ";database=" + database;
            sqltenging = new MySqlConnection(tengistrengur);
        }
        /*Þessi aðferð athugar hvort tenging sé kominn á eða ekki*/
        private bool OpenConnection()
        {
            try
            {
                sqltenging.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                throw ex;
            }
        }
        /*Þessi aðferð lokar tengingu eftir notkun*/
        private bool CloseConnection()
        {
            try
            {
                sqltenging.Close();
                return true;
            }
            catch (MySqlException ex)
            {

                throw ex;
            }
        }        
        public List<string> LesaUt()
        {
            List<string> Faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID, titill, leikstjori, utgefandi, ar, flokkur, link FROM kvikmyndir";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                    Faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return Faerslur;
            }
            return Faerslur;
        }
        public List<string> LesaUtFlokk(string mynd)
        {
            List<string> Faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID, titill, leikstjori, utgefandi, ar, flokkur, link FROM kvikmyndir WHERE flokkur=" + "'" + mynd + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                    Faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return Faerslur;
            }
            return Faerslur;
        }
        public List<string> LesaUtAr(string ar)
        {
            List<string> Faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID, titill, leikstjori, utgefandi, ar, flokkur, link FROM kvikmyndir WHERE ar=" + "'" + ar + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                    Faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return Faerslur;
            }
            return Faerslur;
        }
        public List<string> FinnaMynd(string titill)
        {
            List<string> Faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID, titill, leikstjori, utgefandi, ar, flokkur, link FROM kvikmyndir WHERE titill=" + "'" + titill + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                    Faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return Faerslur;
            }
            return Faerslur;        
        }
        /*Þessi aðferð les úr SQL gagnagrunni allar færslu og birtir í viðeigandi töflu*/
        public List<string> LesautSQLToflu()
        {
            List<string> Faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "INSERT INTO kvikmyndir(ID, titill, leikstjori, utgefandi, ar, flokkur) VALUES";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                /*ExecuteReader: Used to execute a command that will return 0 or more records*/
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                    Faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return Faerslur;
            }
            return Faerslur;
        }
        public void SettInnSqlToflu(string titill, string leikstjori, string utgefandi, string ar, string flokkur, string link)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "INSERT INTO kvikmyndir(titill, leikstjori, utgefandi, ar, flokkur, link) VALUES ('" + titill + "','" + leikstjori + "','" + utgefandi + "','" + ar + "','" + flokkur + "','" + link + "')";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);                
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void Uppfaera(string ID, string titill, string leikstjori, string utgefandi, string ar, string flokkur, string link)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "Update kvikmyndir set titill ='" + titill + "', leikstjori='" + leikstjori + "',utgefandi='" + utgefandi + "',ar='" + ar + "',flokkur='" + flokkur + "' ,link='" + link + "' where ID='" + ID + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void Eyda(string ID)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "Delete FROM kvikmyndir where ID='" + ID + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }        
    }
}
