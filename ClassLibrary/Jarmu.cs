namespace ClassLibrary
{
    public class Jarmu
    {
        public int azonosito { get; set; }
        public string rendszam { get; set; }
        public string marka { get; set; }
        public int urtartalom { get; set; }
        public int ar { get; set; }

        //konstruktor létrehozása, string-ként adja vissza az objektumokat
        public override string ToString()
        {
            return $"{azonosito}:{rendszam}:{marka}:{urtartalom}:{ar}";
        }
    }
}