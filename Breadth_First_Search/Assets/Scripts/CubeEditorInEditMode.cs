using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                
                                                          // Script for snapping the nodes / cube in the editor
                                                          // The size of cube is currently 10 in x and z
[ExecuteInEditMode]                                       // This script will be executed in edit mode. No need to go to play mode
[RequireComponent(typeof(Node))]
public class CubeEditorInEditMode : MonoBehaviour
{
    private Node _node;
    private int _gridSize;                                // Grid snap units; Gets initialized from Node.cs



    private void OnEnable()
    {
        _node = GetComponent<Node>();                     // Need to get node here else wont work
    }



    void Start()
    {
        _gridSize = _node.GridSize;
    }



    void Update()
    {
        SnapToGrid();
    }

    private void SnapToGrid()
    {
        // For snapping to grid
        transform.position = new Vector3(_node.GetPos().x * _gridSize, 0f, _node.GetPos().y * _gridSize);
    }
}
