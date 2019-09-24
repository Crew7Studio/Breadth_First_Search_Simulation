using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                          // The size of cube is currently 10 in x and z
[ExecuteInEditMode]                                       // This script will be executed in edit mode. No need to go to play mode
public class CubeEditorInEditMode : MonoBehaviour
{
    [SerializeField] private int _gridSize = 10;          // Grid snap units

    void Start()
    {
        
    }

    void Update()
    {
        SnapToGrid();
    }

    private void SnapToGrid()
    {
        int newX = Mathf.RoundToInt(transform.position.x / _gridSize);
        int newZ = Mathf.RoundToInt(transform.position.z / _gridSize);

        transform.position = new Vector3(newX * _gridSize, 0f, newZ * _gridSize);
    }
}
