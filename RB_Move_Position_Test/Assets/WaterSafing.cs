using UnityEngine;
using System.Collections;

public class WaterSafing : MonoBehaviour
{
    public float power;
    float _skinWidth = 0f;
    bool _maxUpper;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "head")
        {
            Debug.Log("HEAD enter");
            _maxUpper = false;
        }

        if (col.tag == "Player")
        {
            if (col.GetComponent<EzAnimator>())
            {
                col.GetComponent<EzAnimator>().UnderWater = true;

            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "physical" || col.tag == "Player" && col.GetComponent<Rigidbody>())
        {
            col.GetComponent<Rigidbody>().AddForce(transform.up * power);
        }

        if (col.tag == "Player")
        {
            if (col.GetComponent<CharacterController>())
            {
                if (Input.GetKey(KeyCode.Space) && !_maxUpper)
                {
                    col.GetComponent<CharacterController>().skinWidth = col.GetComponent<CharacterController>().skinWidth + 2f * Time.deltaTime;
                }
                else if (col.GetComponent<CharacterController>().skinWidth > 0.08)
                {
                    col.GetComponent<CharacterController>().skinWidth = col.GetComponent<CharacterController>().skinWidth - 2f * Time.deltaTime;
                }
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "head")
        {
            Debug.Log("HEAD exit");
            _maxUpper = true;
        }

        if (col.tag == "Player")
        {
            if (col.GetComponent<CharacterController>())
                col.GetComponent<CharacterController>().skinWidth = 0.08f;

            if (col.GetComponent<EzAnimator>())
            {
                col.GetComponent<EzAnimator>().UnderWater = false;
            }
        }
    }
}