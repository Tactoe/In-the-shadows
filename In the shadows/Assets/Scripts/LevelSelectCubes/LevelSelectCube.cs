using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCube : MonoBehaviour
{
    public int Level;
    [SerializeField]
    private Material m_LevelUnlockedMaterial;
    [SerializeField]
    private Material m_LevelCompletedMaterial;
    [SerializeField]
    private MeshRenderer m_CubeRenderer;
    [SerializeField]
    private GameObject m_LockIcon;
    [SerializeField]
    private GameObject m_CompletedText;
    // Start is called before the first frame update
    void Start()
    {
        print(GameManager.Instance.LevelsCompleted);
        if (Level <= GameManager.Instance.LevelsCompleted || GameManager.Instance.TestingMode)
        {
            m_CompletedText.SetActive(true);
            m_LockIcon.SetActive(false);
            m_CubeRenderer.material = m_LevelCompletedMaterial;
        }
        else if (Level <= GameManager.Instance.LevelsUnlocked || GameManager.Instance.TestingMode)
        {
            m_LockIcon.SetActive(false);
            m_CubeRenderer.material = m_LevelUnlockedMaterial;
        }
    }
}
