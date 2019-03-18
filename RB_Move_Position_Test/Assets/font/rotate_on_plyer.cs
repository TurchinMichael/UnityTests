using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_on_plyer : MonoBehaviour {
    Transform user;
    Vector3 target;
	// Use this for initialization
	void Start () {
        user = GameObject.Find("IK_Look_Target").transform;
    }
	
	// Update is called once per frame
	void Update () {
        

        transform.LookAt(user);

        transform.Rotate(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
    }
}
