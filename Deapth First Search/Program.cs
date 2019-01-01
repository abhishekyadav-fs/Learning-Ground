using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDFS
{
    // Graph Node whhich contains the adjacency list of that node
    // Suppose Node A which is connected to node B,D,F -> adjacent will contain B,D,F node
    public class Node
    {
        // Node name
        public string nodeName;
        public List<Node> adjacent = new List<Node>();
        public Node(string name)
        {
            this.nodeName = name;
        }
    }
    public class DFSImplementation
    {
        // Grapho look up dictionary
        // key will be the node name and value will be Node itself
        private Dictionary<string, Node> NodeLookup = new Dictionary<string, Node>();

        /// <summary>
        /// Method to get node using the node name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Node GetNode(string name)
        {
            return NodeLookup[name];
        }

        /// <summary>
        /// Method to add edge between two nodes ( Directed )
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void AddEdgeDirected(string source,string destination)
        {
            Node s = GetNode(source);
            Node d = GetNode(destination);
            s.adjacent.Add(d);
        }

        /// <summary>
        /// Method to add undirected edges between two nodes
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void AddEdgeUndirected(string source, string destination)
        {
            Node s = GetNode(source);
            Node d = GetNode(destination);
            s.adjacent.Add(d);
            d.adjacent.Add(s);
        }

        /// <summary>
        /// Method to check if there is a path between two nodes using Deapth First Search
        /// </summary>
        /// <param name="start"></param>
        /// <param name="destination"></param>
        /// <returns bool></returns>
        public bool HasPathDFS(string start,string destination,out List<string> visitedNodes)
        {
            // Getting the node fron NodeLookUp
            Node s = GetNode(start);
            Node f = GetNode(destination);
            Dictionary<Node, bool> visitedTrack = new Dictionary<Node, bool>();
            return DFS(s, f, visitedTrack,out visitedNodes);
        }

        /// <summary>
        /// Method to do DFS on the graph ( Iterative)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="visited"></param>
        /// <returns></returns>
        public bool DFS(Node source, Node destination,Dictionary<Node,bool> visited,out List<string> visitedList)
        {
            List<string> visitedNode = new List<string>();
            // Already at the destination
            if (source == destination)
            {
                visitedNode.Add(source.nodeName);
                visitedList = visitedNode;
                return true;
            }
            // If the source is already visited then return false.
            //As we have already explored for destination node from this node
            if (visited.ContainsKey(source))
            {
                visitedList = null;
                return false;
            }
            // Creating a stack to keep a track of all nodes to be visited 
            Stack<Node> stack = new Stack<Node>();// Created the stack
            // Pushing the source node to stack
            stack.Push(source);
            while (stack.Count != 0)
            {
                Node top = stack.Peek();
                visitedNode.Add(top.nodeName);
                visitedList = visitedNode;
                stack.Pop();
                // Checking if the node is not visited
                if (! visited.ContainsKey(top))
                {
                    // Checking the matching condition
                    if (top.Equals(destination))
                    {
                        return true;
                    }

                    // Marking the current node as visited and pushing all its adjacent node to stack
                    visited.Add(top, true); 
                    foreach (var item in top.adjacent)
                    {
                        if (!visited.ContainsKey(item))
                        {
                            stack.Push(item);
                        }
                    }
                }
            }
            visitedList = null;
            return false;
        }

        /// <summary>
        /// Recursive implementation of DFS
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="visited"></param>
        /// <returns></returns>
        public bool DFSRecursive(Node source,Node destination,Dictionary<Node,bool> visited)
        {
            if (source == destination)
            {
                return true;
            }
            if (visited.ContainsKey(source))
            {
                return false;
            }
            visited.Add(source, true);
            foreach(var item in source.adjacent)
            {
                if (DFSRecursive(item, destination, visited))
                {
                    return true;
                }
                               
            }
            return false;
        }
        
        static void Main(string[] args)
        {
            DFSImplementation obj = new DFSImplementation();
            // Creating the graph
            Node node = new Node("Delhi");
            obj.NodeLookup.Add(node.nodeName, node);
            node = new Node("Mumbai");
            obj.NodeLookup.Add(node.nodeName, node);
            node = new Node("Kolkata");
            obj.NodeLookup.Add(node.nodeName, node);
            node = new Node("Bangalore");
            obj.NodeLookup.Add(node.nodeName, node);
            node = new Node("Chennai");
            obj.NodeLookup.Add(node.nodeName, node);
            node = new Node("Hyderabad");
            obj.NodeLookup.Add(node.nodeName, node);
            node = new Node("Pune");
            obj.NodeLookup.Add(node.nodeName, node);
            node = new Node("Kochi");
            obj.NodeLookup.Add(node.nodeName, node);

            // Adding undirected edges to the graph nodes
            obj.AddEdgeUndirected("Delhi", "Kolkata");
            obj.AddEdgeUndirected("Delhi", "Mumbai");
            obj.AddEdgeUndirected("Kolkata", "Chennai");
            obj.AddEdgeUndirected("Mumbai", "Kolkata");
            obj.AddEdgeUndirected("Chennai", "Bangalore");
            obj.AddEdgeUndirected("Bangalore", "Hyderabad");
            obj.AddEdgeUndirected("Mumbai", "Hyderabad");
            obj.AddEdgeUndirected("Pune", "Kochi");

            // Check if there is path from Delhi to Bangalore
            List<string> visitedNodes;
            bool res = obj.HasPathDFS("Kolkata", "Bangalore",out visitedNodes);

            Console.WriteLine("Path exists between Delhi and Bangalore : "+res);
            if (res)
            {
                foreach(var item in visitedNodes)
                {
                    Console.Write(item+"=>");
                }
            }
            Console.WriteLine();
            //res = obj.HasPathDFS("Kochi", "Kochi");
            //Console.WriteLine("Path exists between Delhi and Bangalore : " + res);
            Console.ReadKey();

        }
    }
}
