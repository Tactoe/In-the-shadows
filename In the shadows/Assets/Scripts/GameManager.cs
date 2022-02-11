using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulties {easy, normal, hard};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float CurrentErrorMargin {
        get; private set;
    }
    [SerializeField]
    private int m_CurrentLevel;
    private int m_LevelCount;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
 
        Instance = this;
        DontDestroyOnLoad(gameObject);
        m_LevelCount = 3;
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

    public void NextLevel()
    {
        if (m_CurrentLevel + 1 <= m_LevelCount)
        {
            m_CurrentLevel++;
            LoadLevel(m_CurrentLevel);
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void LoadLevel(int i_LevelIndex)
    {
        m_CurrentLevel = i_LevelIndex;
        SceneManager.LoadScene("Base Environment");
        SceneManager.LoadScene("Level " + i_LevelIndex, LoadSceneMode.Additive);
    }

    public void StartGame()
    {
        LoadLevel(1);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}