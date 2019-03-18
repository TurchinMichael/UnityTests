using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTime : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            Time.timeScale = Random.Range(0.1f, 1.3f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Time.timeScale = 1f;
    }
}
