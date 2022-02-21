using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowIn : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve m_Curve;
    [SerializeField]
    private float m_GrowTime;
    private float m_Timer;
    private Vector3 m_OriginalScale;
    void Start()
    {
        m_Timer = 0;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * m_Curve.Evaluate(m_Timer / m_GrowTime);
        m_Timer += Time.deltaTime;
    }
}
