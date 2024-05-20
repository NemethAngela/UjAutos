using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;

namespace AutosBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JarmuController : ControllerBase
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=opelek";

        //összes lekérdezése
        [HttpGet]
        public IActionResult GetJarmu()
        {
            List<Jarmu> listJarmuvek = new List<Jarmu>();   //lista létrehozása modell osztály alapján listViragok néven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lekérdezés db-bõl:
            string query = "SELECT azonosito, rendszam, marka, urtartalom, ar FROM jarmu";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Amíg vannak sorok a resultban, beolvassa
            {
                int azonosito = reader.GetInt32(0);
                string rendszam = reader.GetString(1);
                string marka = reader.GetString(2);
                int urtartalom = reader.GetInt32(3);
                int ar = reader.GetInt32(4);
                //osztály neve:
                Jarmu jarmuvek = new Jarmu()
                {
                    azonosito = azonosito, //elsõ tag: modell o-ból, második: db-bõl
                    rendszam = rendszam,
                    marka = marka,
                    urtartalom = urtartalom,
                    ar = ar,


                };
                listJarmuvek.Add(jarmuvek);
            }

            connection.Close();

            return Ok(listJarmuvek);
        }

        //új hozzáadása adatbázishoz
        [HttpPost]
        public IActionResult CreateJarmu([FromBody] Jarmu jarmu)
        {
            const string connectionString = "server=localhost;user=root;password=titok;database=opelek";

            // Ellenõrizzük a modell érvényességét
            if (jarmu == null ||
                jarmu.rendszam == null ||
                jarmu.marka == null ||
                jarmu.urtartalom <= 0 ||
                jarmu.ar <= 0
                )
            {
                return BadRequest("Hiányos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "INSERT INTO jarmu (azonosito, rendszam, marka, urtartalom, ar) VALUES (@azonosito, @rendszam, @marka, @urtartalom, @ar)";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@azonosito", jarmu.azonosito); //modell o. alapján
            cmd.Parameters.AddWithValue("@rendszam", jarmu.rendszam);
            cmd.Parameters.AddWithValue("@marka", jarmu.marka);
            cmd.Parameters.AddWithValue("@urtartalom", jarmu.urtartalom);
            cmd.Parameters.AddWithValue("@ar", jarmu.ar);

            cmd.ExecuteNonQuery();  //long típus szükséges a visszatért-hez
            long insertedJarmu = cmd.LastInsertedId;  //LastInsertedId-el kérem vissza az id-t, amit AutoIncrement-el hoz létre

            connection.Close();

            return Created("azonosito", insertedJarmu);
        }

        // módosítás
        [HttpPut]
        public IActionResult UpdateJarmu([FromBody] Jarmu jarmu)
        {
            // Ellenõrizzük a modell érvényességét
            if (jarmu == null ||
                jarmu.rendszam == null ||
                jarmu.marka == null ||
                jarmu.urtartalom <= 0 ||
                jarmu.ar <= 0)
            {
                return BadRequest("Hiányos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "UPDATE jarmu SET azonosito = @azonosito, rendszam = @rendszam, marka = @marka, urtartalom = @urtartalom, ar = @ar WHERE azonosito = @azonosito";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@azonosito", jarmu.azonosito); //modell o. alapján
            cmd.Parameters.AddWithValue("@rendszam", jarmu.rendszam);
            cmd.Parameters.AddWithValue("@marka", jarmu.marka);
            cmd.Parameters.AddWithValue("@urtartalom", jarmu.urtartalom);
            cmd.Parameters.AddWithValue("@ar", jarmu.ar);

            cmd.ExecuteNonQuery();

            connection.Close();

            return Ok();

        }

        //törlés
        [HttpDelete]
        public IActionResult DeleteJarmu(int azonosito)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string deleteQuery = "DELETE FROM jarmu WHERE azonosito = @azonosito";
            using MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
            cmd.Parameters.AddWithValue("@azonosito", azonosito);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            if (result == 0)
                return NotFound(result);

            return Ok();
        }
    }
}
