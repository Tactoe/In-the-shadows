using UnityEngine;
using UnityEngine.UI;

public class TestingModeToggle : MonoBehaviour
{
    private Toggle m_Toggle;
    
    void Start()
    {
        m_Toggle = GetComponent<Toggle>();
        m_Toggle.isOn = GameManager.Instance.TestingMode;
        m_Toggle.onValueChanged.AddListener(delegate {
            GameManager.Instance.TestingMode = m_Toggle.isOn;
        });
    }
}
