using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VecinoCercano.Models;

namespace VecinoCercano.Services
{
    public static class NNService
    {
        public static IEnumerable<Tuple<double, Node>> CalculatePath(List<Tuple<double, Node>> nodes, List<Tuple<double, Node>> path)
        {
            
            if (path.Count() == 0) 
            { 
                path.Add(nodes[0]);
                nodes.Remove(nodes[0]);
            }
            if (nodes.Count() > 0) 
            {
                var index = path.Count() - 1;
                var nereastNode = CalculateNearestNode(path[index], nodes);
                var node = nodes.Where(n => n.Item2.Id == nereastNode.Item2.Id).First();
                nodes.Remove(node);
                path.Add(nereastNode);
                return CalculatePath(nodes, path);
            }
            return path;
        }

        public static Tuple<double, Node> CalculateNearestNode(Tuple<double, Node> n1, IEnumerable<Tuple<double, Node>> nodes) 
        {
            List<Tuple<double, Node>> nodeDistances = new List<Tuple<double, Node>>();
            foreach (var n in nodes)
            {
                if (n1.Item2.Id != n.Item2.Id)
                {
                    var node = n.Item2;
                    var tuple = new Tuple<double, Node>(n1.Item2.CalculateDistance(node), node);
                    nodeDistances.Add(tuple);
                }
            }
            return nodeDistances.OrderBy(tupla => tupla.Item1).ToList().First();
        }

        public static double CalculateCost(IEnumerable<Tuple<double,Node>> path)
        {
            return path.Sum(n => n.Item1);
        }
    }
}
