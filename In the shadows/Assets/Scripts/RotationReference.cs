using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationReference : MonoBehaviour
{
    public RotationChecker Checker;

    void Start()
    {
        List<Quaternion> m_ValidRotations = new List<Quaternion>();
        for (int i = 0; i < 360; i++)
        {
            m_ValidRotations.Add(transform.rotation);
            transform.Rotate(Vector3.forward, Space.World);
        }
        Checker.SetCorrectRotations(m_ValidRotations);
    }

}
