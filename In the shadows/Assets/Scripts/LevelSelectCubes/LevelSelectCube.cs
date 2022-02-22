using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCube : MonoBehaviour
{
    public int Level;
    [SerializeField]
    private Material m_LevelUnlockedMaterial;
    [SerializeField]
    private MeshRenderer m_CubeRenderer;
    [SerializeField]
    private GameObject m_LockIcon;
    // Start is called before the first frame update
    void Start()
    {
        if (Level <= GameManager.Instance.LevelsUnlocked || GameManager.Instance.TestingMode)
        {
            m_LockIcon.SetActive(false);
            m_CubeRenderer.material = m_LevelUnlockedMaterial;
        }
    }
}
