using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        transform.rotation = target.rotation;
    }
}
