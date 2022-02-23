using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    private Slider m_Slider;
    void Start()
    {
        m_Slider = GetComponent<Slider>();   
        m_Slider.onValueChanged.AddListener(delegate{
            GameManager.Instance.SetVolume(m_Slider.value);
        });
    }

    void Update()
    {
        
    }
}
