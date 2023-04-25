using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VecinoCercano.Models;

namespace VecinoCercano.Services
{
    public static class NodeService
    {
        private static Tuple<double, Node>? GetNode(string line)
        {
            var data = line.Replace("\t", " ").Split(' ').Where(m => !String.IsNullOrWhiteSpace(m)).ToArray();
            try
            {
                if (!String.IsNullOrEmpty(line))
                {
                    var node = new Node(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                    return new Tuple<double, Node>(0, node);
                }
                else
                {
                    throw new Exception();
                }
            }catch(Exception ex)
            {
                throw new Exception(String.Format("El nodo {0}, tiene un error en su formato.", data[0]));
            }

        }

        private static List<Tuple<double, Node>> GetNodes(List<string> lines)
        {
            var nodes = new List<Tuple<double, Node>?>();
            foreach (var line in lines)
            {
                try
                {
                    nodes.Add(GetNode(line));
                }
                catch { }
            }
            if (lines.Count != nodes.Count())
            {
                Console.WriteLine(String.Format("{0} nodos no fueron contabilizados.", lines.Count - nodes.Count()));
            }
            return nodes;
        }


        public static List<Tuple<double, Node>>? ReadFile(string path)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string? line = reader.ReadLine();
                    while (line != null)
                    {
                        if (!String.IsNullOrEmpty(line))
                        {
                            if (line[0] != 'N')
                                lines.Add(line);
                            
                        }
                        line = reader.ReadLine();
                    }
                }
                Console.WriteLine(string.Format("Archivo leído correctamente con {0} nodos. \n", lines.Count()));
                return GetNodes(lines);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }
        
    }
}
