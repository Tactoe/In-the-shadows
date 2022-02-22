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
    public int LevelsCompleted {
        get; private set;
    }
    public bool TestingMode;
    [SerializeField]
    private GameObject m_PauseMenu;
    [SerializeField]
    private int m_CurrentLevel;
    [SerializeField]
    private int m_LevelCount;
    private FadeCanvas m_FadeCanvas;
    private string m_LevelToLoad;
    private bool m_LoadingLevel;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
 
        Instance = this;
        //PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(gameObject);
        LevelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        LevelsCompleted = PlayerPrefs.GetInt("LevelsCompleted", 0);
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
                CurrentErrorMargin = 0.005f;
                break;
            case (Difficulties.hard):
                CurrentErrorMargin = 0.001f;
                break;
        }
    }

    public void UnlockNextLevel()
    {
        if (m_CurrentLevel + 1 <= m_LevelCount)
        {
            if (m_CurrentLevel > LevelsCompleted)
            {
                LevelsCompleted = m_CurrentLevel;
                PlayerPrefs.SetInt("LevelsCompleted", m_CurrentLevel);
            }
            m_CurrentLevel++;
            if (m_CurrentLevel > LevelsUnlocked)
            {
                LevelsUnlocked = m_CurrentLevel;
                PlayerPrefs.SetInt("LevelsUnlocked", LevelsUnlocked);
            }
        }
        StartLoadLevel(0);
    }

    public void StartLoadLevel(int i_LevelIndex)
    {
        ResetPauseMenuState();
        m_FadeCanvas.FadeIn();
        m_CurrentLevel = i_LevelIndex;
        m_LoadingLevel = true;
    }

    private void ResetPauseMenuState()
    {
        m_PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void CompleteLoadLevel()
    {
        m_LoadingLevel = false;
        if (m_CurrentLevel == 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            SceneManager.LoadScene("Base Environment");
            SceneManager.LoadScene("Level " + m_CurrentLevel, LoadSceneMode.Additive);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !m_LoadingLevel && SceneManager.GetActiveScene().name != "Main Menu")
        {
            m_PauseMenu.SetActive(!m_PauseMenu.activeSelf);
            Time.timeScale = m_PauseMenu.activeSelf ? 0 : 1;
        }
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}