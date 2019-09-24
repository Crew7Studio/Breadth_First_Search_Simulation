using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    
    [SerializeField] private int _gridSize = 11;                              // Grid snap units
    public int GridSize { get { return _gridSize; } }

    public bool isExplored = false;
    public Node isExploredFrom;

    private void Start()
    {
        
    }


    private void Update()
    {
        
    }

    // Get current position; Used in CubeEditorInEditMode.cs for snapping to grid
    public Vector2Int GetPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / _gridSize), 
                              Mathf.RoundToInt(transform.position.z / _gridSize));
    }
}
