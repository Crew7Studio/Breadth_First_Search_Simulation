using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPath : MonoBehaviour
{

    [Header("General")]
    [SerializeField] private Node _startingPoint;
    [SerializeField] private Node _endingPoint;
    [SerializeField] private Color _startingPointColor;
    [SerializeField] private Color _endingPointColor;
    [SerializeField] private Color _pathColor;

    private Dictionary<Vector2Int, Node> _block = new Dictionary<Vector2Int, Node>();                           // For storing all the nodes with Node.cs
    private Vector2Int[] _directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };    // Directions to search in BFS
    private Queue<Node> _queue = new Queue<Node>();         // Queue for enqueueing nodes and traversing through them
    private Node _searchingPoint;                           // Current node we are searching
    private bool _isExploring = true;                       // If we are end then it is set to false

    private List<Node> _path = new List<Node>();            // For storing the path traversed
    public List<Node> Path {
        get
        {
            if (_path.Count == 0)                           // If we've already found path, no need to check it again
            {
                LoadAllBlocks();
                BFS();
                CreatePath();
            }
            return _path;
        }
    }

    private void Update()
    {

    }


    // For getting all nodes with Node.cs and storing them in the dictionary
    private void LoadAllBlocks()
    {
        Node[] nodes = FindObjectsOfType<Node>();

        foreach (Node node in nodes) {
            Vector2Int gridPos = node.GetPos();

            // For checking if 2 nodes are in same position; i.e overlapping nodes
            if (_block.ContainsKey(gridPos))
            {
                Debug.LogWarning("2 Nodes present in same position. i.e nodes overlapped.");
            }
            else
            {
                _block.Add(gridPos, node);        // Add the position of each node as key and the Node as the value
            }
        }

    }


    // BFS; For finding the shortest path
    private void BFS()
    {
        _queue.Enqueue(_startingPoint);
        while (_queue.Count > 0 && _isExploring) {
            _searchingPoint = _queue.Dequeue();
            OnReachingEnd();
            ExploreNeighbourNodes();
        }
    }


    // To check if we've reached the Ending point
    private void OnReachingEnd()
    {
        if (_searchingPoint == _endingPoint) {
            _isExploring = false;
        }
        else
        {
            _isExploring = true;
        }
    }


    // Searching the neighbouring nodes
    private void ExploreNeighbourNodes()
    {
        if (!_isExploring) { return; }

        foreach (Vector2Int direction in _directions) {
            Vector2Int neighbourPos = _searchingPoint.GetPos() + direction;

            if (_block.ContainsKey(neighbourPos))               // If the explore neighbour is present in the dictionary _block, which contians all the blocks with Node.cs attached
            {
                Node node = _block[neighbourPos];

                if (node.isExplored) { }                        // For checking if we've already explore this node
                else
                {
                    _queue.Enqueue(node);                       // Enqueueing the node at this position
                    node.isExplored = true;
                    node.isExploredFrom = _searchingPoint;      // Set how we reached the neighbouring node i.e the previous node; for getting the path
                }
            }
        }

    }


    // Creating path using the isExploredFrom var of each node to get the previous node from where we got to this node
    public void CreatePath()
    {
        SetPath(_endingPoint);
        Node previousNode = _endingPoint.isExploredFrom;

        while (previousNode != _startingPoint) {
            SetPath(previousNode);
            previousNode = previousNode.isExploredFrom;
        }

        SetPath(_startingPoint);
        _path.Reverse();
        SetPathColor();
        
    }

    // For adding nodes to the path
    private void SetPath(Node node) {
        _path.Add(node);
    }


   
    // Setting color to nodes
    private void SetPathColor()
    {
        foreach (Node node in _path) {
            node.GetComponentInChildren<Renderer>().material.color = _pathColor;
        }
        SetColor();
    }

    // Setting color to start and end position
    private void SetColor()
    {
        _startingPoint.GetComponentInChildren<Renderer>().material.color = _startingPointColor;
        _endingPoint.GetComponentInChildren<Renderer>().material.color = _endingPointColor;
    }
}
