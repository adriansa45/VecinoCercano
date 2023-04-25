using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VecinoCercano.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Tuple<int,int> Cords { get; set; }

        public Node(int Id, int X, int Y) 
        {
            this.Id= Id;
            this.X = X;
            this.Y = Y;
            Cords = Tuple.Create(X, Y);
        }

        public double CalculateDistance(Node n2)
        {
            return Math.Pow(X - n2.X, 2) + Math.Pow(Y - n2.Y, 2);
        }
        public Node NearestVertice(Node n1, Node n2)
        {
            return CalculateDistance(n1) > CalculateDistance(n2) ? n2 : n1;
        }

    }
}
