using UnityEngine;

public class EraseData : MonoBehaviour
{
    public void ErasePlayerData()
    {
        GameManager.Instance.ErasePlayerData();
    }
}
