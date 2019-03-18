using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        Time.timeScale = 0.3f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Time.timeScale = 1f;
    }
}
