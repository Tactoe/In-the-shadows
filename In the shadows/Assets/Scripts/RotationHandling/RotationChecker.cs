using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct RotationCheckerObject {
    public Transform Target;
    public List<Quaternion> CorrectRotations;
}

public class RotationChecker : MonoBehaviour
{
    [SerializeField]
    private Image m_ProgressionIndicator;
    private List<RotationCheckerObject> m_Checks;
    private bool m_GameWon;
    
    public void SetCorrectRotations(RotationCheckerObject i_ToAdd)
    {
        if (m_Checks == null)
        {
            m_Checks = new List<RotationCheckerObject>();
        }
        m_Checks.Add(i_ToAdd);
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
        m_ProgressionIndicator.fillAmount = totalSimilarity - GameManager.Instance.CurrentErrorMargin;
        if (!m_GameWon
            && (1 - GameManager.Instance.CurrentErrorMargin < totalSimilarity
            || GameManager.Instance.CurrentErrorMargin > totalSimilarity))
        {
            m_GameWon = true;
            GameManager.Instance.UnlockNextLevel();
        }
    }
}
