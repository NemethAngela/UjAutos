using ClassLibrary;
using MySqlConnector;
using System.Text.Json;

namespace AutosGUI
{
    public partial class Form1 : Form
    {
        string connectionString = @"server=localhost;user=root;password=titok;database=opelek";

        Jarmu[] opelek; //opel t�mb l�trehoz�sa, lista helyett
        int index = 0;  //melyik adatot jelen�tj�k meg a t�mbb�l

        public Form1()
        {
            InitializeComponent();
            FillJarmuLista();

            AutotKiir();
        }

        private void FillJarmuLista() //lista felt�lt�se onlyopel.json fajlbol (ezt hoztuk l�tre konzolosban)
        {
            string jsonContent = File.ReadAllText(@"..\..\..\onlyopel.json");  //teljes json f�jl beolvas�sa

            var options = new JsonSerializerOptions     //kis-nagybet� k�l�nbs�gek figyelmen k�v�l hagy�sa az oszt�ly property-jei �s a json v�ltoz�nevek k�z�tt
            {
                PropertyNameCaseInsensitive = true
            };
            opelek = JsonSerializer.Deserialize<Jarmu[]>(jsonContent, options);  //Jarmu objektum list�v� alak�tja a json text-et
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

        private void buttonMent�s_Click(object sender, EventArgs e)
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