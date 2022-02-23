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
    
    void Start()
    {
        if (Level <= GameManager.Instance.LevelsCompleted)
        {
            m_CompletedText.SetActive(true);
            m_LockIcon.SetActive(false);
            m_CubeRenderer.material = m_LevelCompletedMaterial;
        }
        else if (Level <= GameManager.Instance.LevelsUnlocked ||
                GameManager.Instance.TestingMode)
        {
            m_LockIcon.SetActive(false);
            m_CubeRenderer.material = m_LevelUnlockedMaterial;
        }
    }
}
