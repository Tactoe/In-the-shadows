using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button m_Button; 
    void Start()
    {
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(delegate {
            GameManager.Instance.ApplicationQuit();
        });
    }
}
