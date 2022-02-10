using System;
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
        {
            float verticalRotation = 0;
            float horizontalRotation = 0;
            if (GameManager.Instance.VerticalRotationAllowed && Input.GetKey(KeyCode.LeftControl))
                verticalRotation = Input.GetAxis("Mouse Y") * RotationSpeed;
            else if (GameManager.Instance.HorizontalRotationAllowed)
                horizontalRotation = -Input.GetAxis("Mouse X") * RotationSpeed;
                
            transform.Rotate((verticalRotation * Time.deltaTime), (horizontalRotation * Time.deltaTime), 0, Space.World);
        }
        
    }

}