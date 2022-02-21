using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulties {easy, normal, hard};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float CurrentErrorMargin {
        get; private set;
    }
    public bool GameStarted {
        get; private set;
    }
    public int LevelsUnlocked {
        get; private set;
    }
    private FadeCanvas m_FadeCanvas;
    [SerializeField]
    private int m_CurrentLevel;
    [SerializeField]
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
        LevelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        GameStarted = true;
        m_FadeCanvas = GetComponentInChildren<FadeCanvas>();
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
            StartLoadLevel(m_CurrentLevel);
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void StartLoadLevel(int i_LevelIndex)
    {
        m_FadeCanvas.FadeIn();
        m_CurrentLevel = i_LevelIndex;
    }

    public void CompleteLoadLevel()
    {
        SceneManager.LoadScene("Base Environment");
        SceneManager.LoadScene("Level " + m_CurrentLevel, LoadSceneMode.Additive);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}