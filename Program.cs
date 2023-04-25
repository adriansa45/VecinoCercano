using VecinoCercano.Models;
using VecinoCercano.Services;
using Path = VecinoCercano.Models.Path;

Console.WriteLine("Algoritmo del vecino más cercano \n");
Console.WriteLine(@"Escribe la dirección del archivo que 
                    contiene las coordenas de los nodos:");
string path = Console.ReadLine();
//string path = "C:\\Users\\adria\\Downloads\\5nodes.txt";

try
{
    var nodes = NodeService.ReadFile(path);
    
    List<Path> paths = new List<Path>();

    foreach (var n in nodes)
    {
        var nd = new List<Tuple<double, Node>>(nodes);
        var p = new List<Tuple<double, Node>>()
        {
            n
        };
        nd.Remove(n);
        var pathNodes = NNService.CalculatePath(nd, p);
        paths.Add(new Path(pathNodes.ToList()));
    }

    paths.OrderBy(p => p.Cost).First().Print();

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Hasta nunca!!!");
}



Console.ReadLine();


