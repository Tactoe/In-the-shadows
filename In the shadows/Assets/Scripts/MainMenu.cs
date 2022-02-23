using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_LevelSelectCubes;
    void Start()
    {
        bool goStraightToLevelSelect = GameManager.Instance.GoStraightToLevelSelect;
        gameObject.SetActive(!goStraightToLevelSelect);
        if (goStraightToLevelSelect)
        {
            InstantiateLevelSelect();
            GameManager.Instance.GoStraightToLevelSelect = false;
        }
    }

    public void InstantiateLevelSelect()
    {
       GameObject levelSelectCubesGO = Instantiate(m_LevelSelectCubes);
       levelSelectCubesGO.GetComponent<BackToStartMenuButton>().StartMenuGO = gameObject;
    }
}
