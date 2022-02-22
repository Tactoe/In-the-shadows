using UnityEngine;

public class Rotate : MonoBehaviour
{
	private float m_RotateSpeed;

    void Start()
    {
        m_RotateSpeed = Random.Range(3, 5f);
    }

    void Update()
    {
      transform.Rotate(Time.deltaTime * Vector3.forward * m_RotateSpeed);
    }
}
