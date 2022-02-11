using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSelector : MonoBehaviour
{
    [SerializeField]
    private List<RotateObject> m_SelectableObjects;
    private int m_CurrentSelectedIndex;
    private bool m_CanSwitchSelection;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentSelectedIndex = 0;
        m_SelectableObjects[m_CurrentSelectedIndex].SetSelected(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_CanSwitchSelection = true;
            StartCoroutine(SwitchSelectionTimeout());
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (m_CanSwitchSelection)
            {
                m_SelectableObjects[m_CurrentSelectedIndex].SetSelected(false);
                if (m_CurrentSelectedIndex + 1 < m_SelectableObjects.Count)
                {
                    m_CurrentSelectedIndex++;
                }
                else
                {
                    m_CurrentSelectedIndex = 0;
                }
                m_SelectableObjects[m_CurrentSelectedIndex].SetSelected(true);
            }
        }
    }

    IEnumerator SwitchSelectionTimeout()
    {
        yield return new WaitForSeconds(0.5f);
        m_CanSwitchSelection = false;
    }
}
