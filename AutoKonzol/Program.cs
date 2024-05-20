
using ClassLibrary;
using System.Text.Json;

List<Jarmu> jarmuLista = new List<Jarmu>();   //lista létrehozása
jarmuLista = Beolvas();    //itt töltődik fel a lista
List<Jarmu> opel_lista = new List<Jarmu>(); //lista létrehozása csak az opeleknek


string onlyOpelFileName = @"..\..\..\onlyopel.json";    //ez jön létre fájlbaírás után

JarmuListatKiir();
KivonatOpel();


static List<Jarmu> Beolvas()
{
    string jsonContent = File.ReadAllText(@"..\..\..\jarmuvek_opel.json");  //teljes json fájl beolvasása

    var options = new JsonSerializerOptions     //kis-nagybetű különbségek figyelmen kívül hagyása az osztály property-jei és a json változónevek között
    {
        PropertyNameCaseInsensitive = true
    };
    return JsonSerializer.Deserialize<List<Jarmu>>(jsonContent, options);  //Jarmu objektum listává alakítja a json text-et

}

void JarmuListatKiir()
{
    foreach (var jarmu in jarmuLista)
    {
        Console.WriteLine(jarmu);
    }
}

// opel márkájúakat töltse be egy másik opel_lista-ba
void KivonatOpel()
{
    opel_lista.AddRange(jarmuLista.Where(x => x.marka == "Opel"));

    string jsonContent = JsonSerializer.Serialize<List<Jarmu>>(opel_lista); //json string-gé alakítja

    File.WriteAllText(onlyOpelFileName, jsonContent);   //fájlbaír

}