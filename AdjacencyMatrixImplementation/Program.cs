using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAdjacencyListRepresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> vertices = new List<string>();
            vertices.Add("Delhi");
            vertices.Add("Kolkata");
            vertices.Add("Mumbai");
            vertices.Add("Chennai");
            vertices.Add("Bangalore");
            vertices.Add("Hyderabad");

            int[,] AdjMatrix = new int[vertices.Count, vertices.Count];

            // Setting the edges in the matrix
            // Delhi-Kolkata, Delhi-Mumbai, Chennai- Bangalore, Bangalore-Hyderabad,Mumbai-Kolkata,Kolkata-Chennai
            AdjMatrix[0, 1] = 1;
            AdjMatrix[1, 0] = 1;
            AdjMatrix[0, 2] = 1;
            AdjMatrix[2, 0] = 1;
            AdjMatrix[3, 4] = 1;
            AdjMatrix[4, 3] = 1;
            AdjMatrix[4, 5] = 1;
            AdjMatrix[5, 4] = 1;
            AdjMatrix[1, 2] = 1;
            AdjMatrix[2, 1] = 1;
            AdjMatrix[1, 3] = 1;
            AdjMatrix[3, 1] = 1;

            Console.WriteLine("Get all cities connected to Delhi");
            var list = GetListOfConnectedNodeOfGivenNode("Delhi", AdjMatrix, vertices);
            if(list!=null && list.Count != 0)
            {
                foreach(var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("Checking if Delhi is connected to Chennai - ");
            Console.WriteLine(CheckIfGivenNodesAreConnected("Delhi", "Chennai",AdjMatrix,vertices));

            Console.ReadKey();
        }

        // Method to get all the connected nodes of a given node
        public static List<string> GetListOfConnectedNodeOfGivenNode(string node,int[,] adjMatrix,List<string> vertices)
        {
            List<string> res = new List<string>();
            for(int i = 0; i < vertices.Count; i++)
            {
                if (adjMatrix[vertices.IndexOf(node), i] == 1)
                {
                    res.Add(vertices[i]);
                }
            }
            return res;
        }

        // Method to check if the nodes are connected to each other
        public static bool CheckIfGivenNodesAreConnected(string node,string secondNode,int[,] adjMatrix,List<string> vertices)
        {
            if( adjMatrix[vertices.IndexOf(node),vertices.IndexOf(secondNode)] == 1)
            {
                return true;
            }
            return false;
        }
    }
}
