using ClassLibrary;
using MySqlConnector;
using System.Text.Json;

namespace AutosGUI
{
    public partial class Form1 : Form
    {
        string connectionString = @"server=localhost;user=root;password=titok;database=opelek";

        Jarmu[] opelek; //opel tömb létrehozása, lista helyett
        int index = 0;  //melyik adatot jelenítjük meg a tömbbõl

        public Form1()
        {
            InitializeComponent();
            FillJarmuLista();

            AutotKiir();
        }

        private void FillJarmuLista() //lista feltöltése onlyopel.json fajlbol (ezt hoztuk létre konzolosban)
        {
            string jsonContent = File.ReadAllText(@"..\..\..\onlyopel.json");  //teljes json fájl beolvasása

            var options = new JsonSerializerOptions     //kis-nagybetû különbségek figyelmen kívül hagyása az osztály property-jei és a json változónevek között
            {
                PropertyNameCaseInsensitive = true
            };
            opelek = JsonSerializer.Deserialize<Jarmu[]>(jsonContent, options);  //Jarmu objektum listává alakítja a json text-et
        }

        private void buttonBezar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonElozo_Click(object sender, EventArgs e)
        {
            if (index <= 0)
                return;

            index--;
            AutotKiir();
        }

        private void buttonKovetkezo_Click(object sender, EventArgs e)
        {
            if (index >= opelek.Length - 1)
                return;

            index++;
            AutotKiir();
        }

        private void AutotKiir()
        {
            textBox1.Text = opelek[index].azonosito.ToString();
            textBox2.Text = opelek[index].rendszam;
            textBox3.Text = opelek[index].marka;
            textBox4.Text = opelek[index].urtartalom.ToString();
            textBox5.Text = opelek[index].ar.ToString();
        }

        private void buttonMentés_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = @"server=localhost;user=root;password=titok;database=opelek";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string opelekInsertSql = "INSERT INTO jarmu (azonosito, rendszam, marka, urtartalom, ar) VALUES (@azonosito, @rendszam, @marka, @urtartalom, @ar)";
                
                MySqlCommand opelekInsert = new MySqlCommand(opelekInsertSql, connection);
                opelekInsert.Parameters.AddWithValue("@azonosito", opelek[index].azonosito);
                opelekInsert.Parameters.AddWithValue("@rendszam", opelek[index].rendszam);
                opelekInsert.Parameters.AddWithValue("@marka", opelek[index].marka); 
                opelekInsert.Parameters.AddWithValue("@urtartalom", opelek[index].urtartalom);
                opelekInsert.Parameters.AddWithValue("@ar", opelek[index].ar);
                opelekInsert.ExecuteNonQuery();
                
                connection.Close();
                                                              
            }
            catch (Exception ex)
            {
                MessageBox.Show("HIBA: " + ex.Message);
            }
        }
    }
}