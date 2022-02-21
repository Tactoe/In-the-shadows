using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private bool m_HorizontalRotationAllowed;
    [SerializeField]
    private bool m_VerticalRotationAllowed;
    [SerializeField]
    private bool m_LevelWithSelect;
    [SerializeField]
    private bool m_IsAnchor;
    private float m_RotationSpeed = 1000;
    private bool m_Selected = false;

    public void SetSelected(bool i_Selected)
    {
        m_Selected = i_Selected;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if ((m_LevelWithSelect && !Input.GetKey(KeyCode.LeftShift) && m_Selected) ||
                (m_LevelWithSelect && Input.GetKey(KeyCode.LeftShift) && m_IsAnchor) ||
                !m_LevelWithSelect)
            {
                float verticalRotation = 0;
                float horizontalRotation = 0;
                if (m_VerticalRotationAllowed && Input.GetKey(KeyCode.LeftControl))
                    verticalRotation = Input.GetAxis("Mouse Y") * m_RotationSpeed;
                else if (m_HorizontalRotationAllowed)
                    horizontalRotation = -Input.GetAxis("Mouse X") * m_RotationSpeed;
                transform.Rotate((verticalRotation * Time.deltaTime), (horizontalRotation * Time.deltaTime), 0, Space.World);
            }
        }
    }
}