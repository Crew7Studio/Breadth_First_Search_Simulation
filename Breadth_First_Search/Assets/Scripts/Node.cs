using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Singleton
    private static Node _instance;
    public static Node Instance { get { return _instance; } }

    [SerializeField] private int _gridSize = 11;                              // Grid snap units
    public int GridSize { get { return _gridSize; } }



    private void OnEnable()
    {
        if (_instance == null) { _instance = this; }         // Use this while using Singleton
    }


    // Get current position; Used in CubeEditorInEditMode.cs for snapping to grid
    public Vector2Int GetPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / _gridSize), 
                              Mathf.RoundToInt(transform.position.z / _gridSize));
    }
}
