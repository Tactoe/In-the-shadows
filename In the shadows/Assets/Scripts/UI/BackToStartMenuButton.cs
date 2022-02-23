using UnityEngine;
using UnityEngine.UI;

public class BackToStartMenuButton : MonoBehaviour
{
    public GameObject StartMenuGO;
    [SerializeField]
    private Button m_Button;
    void Start()
    {
        m_Button.onClick.AddListener(delegate {
            StartMenuGO.SetActive(true);
            Destroy(gameObject);
        });
    }


}
