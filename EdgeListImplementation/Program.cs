using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementation
{
    public struct GraphEdge
    {
        public int StartVertexIndex;
        public int EndVertexIndex;
        public int Weight;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Edge List Representation of Graph
            // List of Vertices as string
            List<string> Vertex = new List<string>();    
            // List of Edges which is of type GraphEdge        
            List<GraphEdge> Edges = new List<GraphEdge>();
            Console.WriteLine("Creating Graph");
            CreateGraphEdgeList(Vertex, Edges);
            // Getting all connected nodes of given node
            var list = FindAllAdjacentNodesOfGivenNode("Delhi", Edges, Vertex);
            if (list != null)
            {
                foreach (var node in list) { Console.WriteLine("All connected nodes with "+ "Delhi are : "+ node); }
            }

            bool res = FindTwoNodesAreConnectedOrNot("Delhi", "Chennai", Edges, Vertex);
            Console.WriteLine(res);
            Console.ReadKey();

        }
        // Create Undirected Graph
        public static void CreateGraphEdgeList(List<string> Vertex,List<GraphEdge> Edges)
        {
            Vertex.Add("Delhi");
            Vertex.Add("Kolkata");
            Vertex.Add("Mumbai");
            Vertex.Add("Chennai");
            Vertex.Add("Bangalore");

            GraphEdge edge = new GraphEdge();
            edge.StartVertexIndex = Vertex.IndexOf(Vertex[0]);
            edge.EndVertexIndex = Vertex.IndexOf(Vertex[1]);
            edge.Weight = 1500;
            Edges.Add(edge);

            edge.StartVertexIndex = Vertex.IndexOf(Vertex[0]);
            edge.EndVertexIndex = Vertex.IndexOf(Vertex[2]);
            edge.Weight = 1700;
            Edges.Add(edge);

            edge.StartVertexIndex = Vertex.IndexOf(Vertex[1]);
            edge.EndVertexIndex = Vertex.IndexOf(Vertex[3]);
            edge.Weight = 1400;
            Edges.Add(edge);

            edge.StartVertexIndex = Vertex.IndexOf(Vertex[3]);
            edge.EndVertexIndex = Vertex.IndexOf(Vertex[4]);
            edge.Weight = 600;
            Edges.Add(edge);

            edge.StartVertexIndex = Vertex.IndexOf(Vertex[1]);
            edge.EndVertexIndex = Vertex.IndexOf(Vertex[2]);
            edge.Weight = 2100;
            Edges.Add(edge);


        }

        // Finding all connected nodes
        public static List<string> FindAllAdjacentNodesOfGivenNode(string node,List<GraphEdge> Edges,List<string> Vertex)
        {
            List<string> ListOfConnectedNodes = new List<string>();
            foreach(var item in Edges)
            {
                if(item.StartVertexIndex==Vertex.IndexOf(node) || item.EndVertexIndex == Vertex.IndexOf(node))
                {
                    if(item.StartVertexIndex != Vertex.IndexOf(node)) { ListOfConnectedNodes.Add(Vertex[item.EndVertexIndex]); }
                    else { ListOfConnectedNodes.Add(Vertex[item.EndVertexIndex]); }
                }
            }
            return ListOfConnectedNodes;
        }

        // Find two given nodes are connected or not
        public static bool FindTwoNodesAreConnectedOrNot(string node,string secondNode, List<GraphEdge> Edges, List<string> Vertex)
        {
            foreach (var item in Edges)
            {
                if ((item.StartVertexIndex == Vertex.IndexOf(node) || item.EndVertexIndex == Vertex.IndexOf(node))
                    && (item.StartVertexIndex == Vertex.IndexOf(secondNode) || item.EndVertexIndex == Vertex.IndexOf(secondNode)))
                {
                    return true;
                }
            }
            return false;
        }
    }
   
   
}
