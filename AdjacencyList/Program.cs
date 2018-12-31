using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAdjacencyListImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adjacency List  Representation of a graph (Undirected unweighted )
            // Implementation using Dictionary. Each node will be key, and all list of all connected nodes will be 
            // values to the dictionary
            // In case of wighted graph, keys will be one node (struct, with destination node and weight of edge)
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            graph.Add("Delhi", new List<string>
            {
                "Kolkata","Mumbai","Hyderabad"
            });
            graph.Add("Kolkata", new List<string>
            {
                "Chennai","Mumbai","Hyderabad"
            });
            graph.Add("Bangalore", new List<string>
            {
                "Chennai","Mumbai","Hyderabad"
            });
            graph.Add("Mumbai", new List<string>
            {
                "Delhi","Kolkata","Bangalore"
            });
            graph.Add("Chennai", new List<string>
            {
                "Kolkata","Bangalore","Hyderabad"
            });
            graph.Add("Hyderabad", new List<string>
            {
                "Delhi","Kolkata","Bangalore","Chennai"
            });


            // 
            GetAllConnectedNodesOfGivenNode("Hyderabad", graph);
        }

        /// <summary>
        /// 
        /// Method to get all connected nodes to a given node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="graph"></param>
        public static void GetAllConnectedNodesOfGivenNode(string node,Dictionary<string,List<string>> graph)
        {
            var connectedNodes = graph[node];
            foreach(var item in connectedNodes)
            {
                Console.WriteLine("All connected nodes to "+node.ToUpper() +" are :"+ item);
            }

        }


        /// <summary>
        /// 
        /// Method to check if two nodes are connected or not
        /// </summary>
        /// <param name="node"></param>
        /// <param name="secondNode"></param>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool CheckIfTwoNodesAreConnected(string node,string secondNode, Dictionary<string,List<string>> graph)
        {
            if (graph.ContainsKey(node))
            {
                if(graph[node].Contains(secondNode) || graph[secondNode].Contains(node))
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
