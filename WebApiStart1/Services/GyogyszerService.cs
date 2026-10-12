using WebApiStart1.Models;
using MySql.Data.MySqlClient;

namespace WebApiStart1.Services
{
    public class GyogyszerService
    {
        //GetAll
        public List<Gyogyszer> GetAllGyogyszer()
        {
            try
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();
                string? connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //A beolvasott adatok feldolgozása
                    Gyogyszer gyogyszer = new Gyogyszer();
                    gyogyszer.Id = reader.GetInt32("Id");
                    gyogyszer.Nev = reader.GetString("Nev");
                    gyogyszer.Hatoanyag = reader.GetString("Hatoanyag");
                    gyogyszer.Venykoteles = reader.GetBoolean("Venykoteles");
                    gyogyszer.kepnev = reader.GetString("Kepnev");
                    gyogyszerek.Add(gyogyszer);

                }
                conn.Close();
                return gyogyszerek;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                //Console.WriteLine("Hiba: "+ex.Message);
                //return gyógyszerek;

            }
        }

        //GetById
        public Gyogyszer GetByIdGyogyszer(int id)
        {
            Gyogyszer result = new Gyogyszer();
            try
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();
                string? connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result.Id = reader.GetInt32("Id");
                    result.Nev = reader.GetString("Nev");
                    result.Hatoanyag = reader.GetString("Hatoanyag");
                    result.Venykoteles = reader.GetBoolean("Venykoteles");
                    result.kepnev = reader.GetString("Kepnev");
                    return result;
                }
                else
                {
                    Console.WriteLine("Nincs ilyen gyógyszer");
                }
                conn.Close();
                return null;
            }

            catch (Exception ex)
            {
                throw new Exception("Hiba a gyógyszer lekérdezésekor: " + ex.Message);
                //Console.WriteLine("Hiba: "+ex.Message);
                //return null;
            }
        }
    }
}