using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField]
    private Difficulties m_ButtonDifficulty;
    [SerializeField]
    private TextMeshProUGUI m_CurrentDifficultyText;
    private Button m_Button;
    // Start is called before the first frame update
    void Start()
    {
        m_Button = GetComponent<Button>();
        if (GameManager.Instance.CurrentDifficulty == m_ButtonDifficulty)
        {
            SetCurrentDifficultyText();
        }
        m_Button.onClick.AddListener(delegate {
            SetCurrentDifficultyText();
            GameManager.Instance.SetDifficulty(m_ButtonDifficulty);
        });
    }

    private void SetCurrentDifficultyText()
    {
        string difficulty = "";
        switch (m_ButtonDifficulty)
        {
            case Difficulties.easy:
                difficulty = "Easy";
                break;
            case Difficulties.normal:
                difficulty = "Normal";
                break;
            case Difficulties.hard:
                difficulty = "Hard";
                break;
        }
        m_CurrentDifficultyText.text = "Current: " + difficulty;
    }
}
