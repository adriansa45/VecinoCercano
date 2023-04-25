using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VecinoCercano.Services;

namespace VecinoCercano.Models
{
    public class Path
    {
        public List<Tuple<double, Node>> Nodes { get; set; }
        public double Cost { get; set; }

        public Path(List<Tuple<double, Node>> nodes) 
        { 
            this.Nodes = nodes;
            Cost = NNService.CalculateCost(nodes);
        }
        
        public void Print()
        {
            if (Nodes == null) return;

            Console.WriteLine("El orden de los nodos es el siguiente:");
            for (int i = 0; i < Nodes.Count(); i++)
            {
                if (i != Nodes.Count - 1)
                {
                    Console.Write(Nodes[i].Item2.Id + " - ");
                }
                else
                {
                    Console.Write(Nodes[i].Item2.Id);
                }
            }
            Console.WriteLine(String.Format("\nEl costo de este camino es de {0} unidades.",Cost));
        }
    }
}
