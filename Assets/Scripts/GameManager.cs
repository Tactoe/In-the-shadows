using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gm;

    public static GameManager Instance { get { return _gm; } }


    private void Awake()
    {
        if (_gm != null && _gm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _gm = this;
            DontDestroyOnLoad(_gm);
        }
    }

    public void ChangeScene(int sc)
    {
        if (SceneManager.sceneCountInBuildSettings > sc && sc >= 0)
            SceneManager.LoadScene(sc);
    }
}
