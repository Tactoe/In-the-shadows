using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    [SerializeField]
    private float m_MinVal;
    [SerializeField]
    private float m_MaxVal;
    [SerializeField]
    private float m_FlickerSpeed;
    private bool m_Increasing;
    private Light m_Light;

    void Start()
    {
        m_Light = GetComponent<Light>();
    }

    void Update()
    {
        if (m_Increasing)
        {
            m_Light.intensity += Time.deltaTime * m_FlickerSpeed;
            if (m_Light.intensity > m_MaxVal)
            {
                m_Increasing = false;
            }
        }
        else
        {
            m_Light.intensity -= Time.deltaTime * m_FlickerSpeed;
            if (m_Light.intensity < m_MinVal)
            {
                m_Increasing = true;
            }

        }
        
    }
}
