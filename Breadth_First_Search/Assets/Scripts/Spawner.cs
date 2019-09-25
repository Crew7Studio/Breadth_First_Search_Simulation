using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    void Start()
    {
        Instantiate(_playerPrefab, transform.position, Quaternion.identity);
    }
}
