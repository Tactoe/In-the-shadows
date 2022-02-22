using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    [SerializeField]
    private float m_fadeDuration;

    private Image m_FadeImg;
    private bool m_FadingIn;
    private bool m_FadingOut;
    private float m_Timer;
    
    void Start()
    {
        m_FadeImg = GetComponentInChildren<Image>();
        m_Timer = 0;        
    }

    void Update()
    {
        if (m_FadingIn || m_FadingOut)
        {
            float alpha = (m_Timer / m_fadeDuration);
            if (m_FadingOut)
                alpha = 1 - alpha;
            m_FadeImg.color = new Color(0, 0, 0, alpha);
            m_Timer += Time.deltaTime;
            if (m_Timer >= m_fadeDuration)
            {
                if (m_FadingIn)
                {
                    GameManager.Instance.CompleteLoadLevel();
                    FadeOut();
                    m_FadingIn = false;
                }
                else
                    m_FadingOut = false;
                m_Timer = 0;
            }
        }
    }

    public void FadeIn()
    {
        m_FadeImg.color = new Color(0, 0, 0, 0);
        m_FadingIn = true;
    }
    
    public void FadeOut()
    {
        m_FadeImg.color = new Color(0, 0, 0, 1);
        m_FadingOut = true;
    }
}
