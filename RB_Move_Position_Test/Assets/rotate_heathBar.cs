using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_heathBar : MonoBehaviour
{
    public Transform user;
    Vector3 target;
    void Start()
    {
        user = GameObject.Find("IK_Look_Target").transform;
    }

    void Update()
    {
        transform.LookAt(user);

        transform.Rotate(transform.localRotation.x, transform.localRotation.y + 180, transform.localRotation.z);
    }
}
