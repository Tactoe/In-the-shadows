using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelSlideIn : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve m_Curve;
    [SerializeField]
    private RectTransform m_PuzzleCompleteRT;
    [SerializeField]
    private RectTransform m_ButtonsRT;
    [SerializeField]
    private float m_SlideTime;
    private float m_Timer;

    void Start()
    {
        ResetTextPositions();
    }

    void OnDisable()
    {
        ResetTextPositions();
    }

    void Update()
    {
        if (m_Timer < m_SlideTime)
        {
            m_PuzzleCompleteRT.anchoredPosition = new Vector2( m_Curve.Evaluate(m_Timer / m_SlideTime), m_PuzzleCompleteRT.anchoredPosition.y);
            m_ButtonsRT.anchoredPosition =  new Vector2(-m_Curve.Evaluate(m_Timer / m_SlideTime), m_ButtonsRT.anchoredPosition.y);
            m_Timer += Time.deltaTime;
        }
    }
    
    private void ResetTextPositions()
    {
        m_PuzzleCompleteRT.anchoredPosition = new Vector2(m_Curve.Evaluate(0), m_PuzzleCompleteRT.anchoredPosition.y);
        m_ButtonsRT.anchoredPosition = new Vector2(-m_Curve.Evaluate(0), m_ButtonsRT.anchoredPosition.y);
        m_Timer = 0;
    }
}
