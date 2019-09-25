using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    [SerializeField] private string _nextLevel;

    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
    }



    public void LoadNextLevel() {
        SceneManager.LoadScene(_nextLevel);
    }
}
