using System.Collections.Generic;
using UnityEngine;
using TMPro;

public struct RotationCheckerObject {
    public Transform Target;
    public List<Quaternion> CorrectRotations;
}

public class RotationChecker : MonoBehaviour
{
    private List<RotationCheckerObject> m_Checks;
    private TextMeshProUGUI m_Text;
    
    public void SetCorrectRotations(RotationCheckerObject i_ToAdd)
    {
        if (m_Checks == null)
        {
            m_Checks = new List<RotationCheckerObject>();
        }
        m_Checks.Add(i_ToAdd);
    }

    void Start()
    {
        m_Text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        float totalSimilarity = 0;
        foreach (RotationCheckerObject check in m_Checks)
        {
            float similarity = 0;
            foreach(Quaternion correctRotation in check.CorrectRotations)
            {
                similarity = Mathf.Max(similarity, Mathf.Abs(Quaternion.Dot(correctRotation, check.Target.rotation)));
            }
            totalSimilarity += similarity;
        }
        totalSimilarity /= m_Checks.Count;
        m_Text.text = "Similarity: " + totalSimilarity + "\n" + (1 - GameManager.Instance.CurrentErrorMargin < totalSimilarity);
        if (1 - GameManager.Instance.CurrentErrorMargin < totalSimilarity)
        {
            GameManager.Instance.NextLevel();
        }
    }
}
