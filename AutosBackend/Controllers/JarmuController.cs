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

        //�sszes lek�rdez�se
        [HttpGet]
        public IActionResult GetJarmu()
        {
            List<Jarmu> listJarmuvek = new List<Jarmu>();   //lista l�trehoz�sa modell oszt�ly alapj�n listViragok n�ven
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //lek�rdez�s db-b�l:
            string query = "SELECT azonosito, rendszam, marka, urtartalom, ar FROM jarmu";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader(); // SELECT -> ExecuteReader !!!
                                                                // Ha DELETE, UPDATE, INSERT -> ExecuteNonQuery !!!
            while (reader.Read())   // Am�g vannak sorok a resultban, beolvassa
            {
                int azonosito = reader.GetInt32(0);
                string rendszam = reader.GetString(1);
                string marka = reader.GetString(2);
                int urtartalom = reader.GetInt32(3);
                int ar = reader.GetInt32(4);
                //oszt�ly neve:
                Jarmu jarmuvek = new Jarmu()
                {
                    azonosito = azonosito, //els� tag: modell o-b�l, m�sodik: db-b�l
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

        //�j hozz�ad�sa adatb�zishoz
        [HttpPost]
        public IActionResult CreateJarmu([FromBody] Jarmu jarmu)
        {
            const string connectionString = "server=localhost;user=root;password=titok;database=opelek";

            // Ellen�rizz�k a modell �rv�nyess�g�t
            if (jarmu == null ||
                jarmu.rendszam == null ||
                jarmu.marka == null ||
                jarmu.urtartalom <= 0 ||
                jarmu.ar <= 0
                )
            {
                return BadRequest("Hi�nyos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "INSERT INTO jarmu (azonosito, rendszam, marka, urtartalom, ar) VALUES (@azonosito, @rendszam, @marka, @urtartalom, @ar)";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@azonosito", jarmu.azonosito); //modell o. alapj�n
            cmd.Parameters.AddWithValue("@rendszam", jarmu.rendszam);
            cmd.Parameters.AddWithValue("@marka", jarmu.marka);
            cmd.Parameters.AddWithValue("@urtartalom", jarmu.urtartalom);
            cmd.Parameters.AddWithValue("@ar", jarmu.ar);

            cmd.ExecuteNonQuery();  //long t�pus sz�ks�ges a visszat�rt-hez
            long insertedJarmu = cmd.LastInsertedId;  //LastInsertedId-el k�rem vissza az id-t, amit AutoIncrement-el hoz l�tre

            connection.Close();

            return Created("azonosito", insertedJarmu);
        }

        // m�dos�t�s
        [HttpPut]
        public IActionResult UpdateJarmu([FromBody] Jarmu jarmu)
        {
            // Ellen�rizz�k a modell �rv�nyess�g�t
            if (jarmu == null ||
                jarmu.rendszam == null ||
                jarmu.marka == null ||
                jarmu.urtartalom <= 0 ||
                jarmu.ar <= 0)
            {
                return BadRequest("Hi�nyos adatok");
            }

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = "UPDATE jarmu SET azonosito = @azonosito, rendszam = @rendszam, marka = @marka, urtartalom = @urtartalom, ar = @ar WHERE azonosito = @azonosito";
            using MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@azonosito", jarmu.azonosito); //modell o. alapj�n
            cmd.Parameters.AddWithValue("@rendszam", jarmu.rendszam);
            cmd.Parameters.AddWithValue("@marka", jarmu.marka);
            cmd.Parameters.AddWithValue("@urtartalom", jarmu.urtartalom);
            cmd.Parameters.AddWithValue("@ar", jarmu.ar);

            cmd.ExecuteNonQuery();

            connection.Close();

            return Ok();

        }

        //t�rl�s
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
