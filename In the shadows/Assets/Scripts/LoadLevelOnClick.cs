using UnityEngine;

public class LoadLevelOnClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                LevelSelectCube levelSelect = raycastHit.collider.gameObject.GetComponent<LevelSelectCube>();
                if (levelSelect != null)
                {
                    GameManager.Instance.StartLoadLevel(levelSelect.Level);
                }
            }
        }
    }
}
