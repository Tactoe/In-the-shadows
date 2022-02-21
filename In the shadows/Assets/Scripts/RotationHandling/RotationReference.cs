using System.Collections.Generic;
using UnityEngine;

public class RotationReference : MonoBehaviour
{
    public RotationChecker Checker;
    public Transform Target;

    void Start()
    {
        List<Quaternion> validRotations = new List<Quaternion>();
        for (int i = 0; i < 360; i++)
        {
            validRotations.Add(transform.rotation);
            transform.Rotate(Vector3.forward, Space.World);
        }
        RotationCheckerObject toAdd;
        toAdd.CorrectRotations = validRotations;
        toAdd.Target = Target;
        Checker.SetCorrectRotations(toAdd);
    }
}
