using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), (-Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
        
    }
}