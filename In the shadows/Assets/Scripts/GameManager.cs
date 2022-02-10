using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool HorizontalRotationAllowed;
    public bool VerticalRotationAllowed;
    public bool MovementAllowed;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
 
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}