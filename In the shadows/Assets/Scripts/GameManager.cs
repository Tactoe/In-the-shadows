using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulties {easy, normal, hard};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float CurrentErrorMargin {
        get; private set;
    }
    
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
 
        Instance = this;
        SetDifficulty(Difficulties.normal);
    }
    
    public void SetDifficulty(Difficulties i_NewDifficulty)
    {
        switch (i_NewDifficulty)
        {
            case (Difficulties.easy):
                CurrentErrorMargin = 0.01f;
                break;
            case (Difficulties.normal):
                CurrentErrorMargin = 0.001f;
                break;
            case (Difficulties.hard):
                CurrentErrorMargin = 0.0001f;
                break;
        }
    }

    public void LoadScene(string i_SceneName)
    {
        SceneManager.LoadScene(i_SceneName);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}