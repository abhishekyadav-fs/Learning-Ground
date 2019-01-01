#Breadth First Search
> BFS
```
void bfs(node start) {
  queue<node> q;
  q.enqueue(start);
  mark start as visited
  while (q.Count == > 0) {
    front = q.peek();
    q.dequeue(); 

    check for termination condition (have we reached the node we want to?) 

    add all of front's unvisited neighbors to the queue
    mark all of front's unvisited neighbors as visited
  }
}
```
