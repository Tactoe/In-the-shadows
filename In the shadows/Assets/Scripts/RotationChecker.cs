using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotationChecker : MonoBehaviour
{
    public Transform TargetTransform;
    public float ErrorMargin;
    
    private TextMeshProUGUI m_text;
    private List<Quaternion> m_CorrectRotations;
    
    public void SetCorrectRotations(List<Quaternion> i_Rotations)
    {
        m_CorrectRotations = i_Rotations;
    }

    void Start()
    {
        m_text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        float similarity = 0;
        foreach(Quaternion correctRotation in m_CorrectRotations)
        {
            similarity = Mathf.Max(similarity, Mathf.Abs(Quaternion.Dot(correctRotation, TargetTransform.rotation)));
        }
        m_text.text = "Similarity: " + similarity + "\n" + (1 - ErrorMargin < similarity);
    }
}
