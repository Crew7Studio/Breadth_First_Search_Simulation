using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SearchPath _searchPath;

    [SerializeField] private float _movementSmoothing;
    [SerializeField] private float _yOffset;


    private void Start()
    {
        _searchPath = FindObjectOfType<SearchPath>();
        if(_searchPath.Path != null)        // If the player has a path to move on 
        {
            StartCoroutine(Movement(_searchPath.Path));
        }
    }

    IEnumerator Movement(List<Node> paths)
    {
        foreach (Node path in paths) {

            Vector3 pos = path.transform.position;

            transform.position = new Vector3(pos.x, _yOffset, pos.z);
            yield return new WaitForSeconds(_movementSmoothing);
        }

        GameManager.Instance.LoadNextLevel();
        Destroy(gameObject);
    }
}
