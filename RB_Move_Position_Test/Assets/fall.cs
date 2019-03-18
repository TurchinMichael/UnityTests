using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour {
	void Start () {
        foreach (GameObject _object in GameObject.FindGameObjectsWithTag("body"))
        {
            if (_object.GetComponent<CapsuleCollider>())
                _object.GetComponent<CapsuleCollider>().enabled = false;
            if (_object.GetComponent<BoxCollider>())
                _object.GetComponent<BoxCollider>().enabled = false;
            if (_object.GetComponent<CharacterJoint>())
            {
                _object.GetComponent<CharacterJoint>().massScale = 0;
                _object.GetComponent<CharacterJoint>().connectedMassScale = 0;
            }
        }
	}

    public void Rise_Death(bool rise)
    {
        //foreach (weapon child in GetComponentsInChildren<weapon>())
        //{
        //    Components(child.transform, !rise);
        //}


        foreach (GameObject _object in GameObject.FindGameObjectsWithTag("body"))
        {
            if (_object.GetComponent<CapsuleCollider>())
                _object.GetComponent<CapsuleCollider>().enabled = rise;
            if (_object.GetComponent<BoxCollider>())
                _object.GetComponent<BoxCollider>().enabled = rise;
            if (_object.GetComponent<EzAnimator>())
                _object.GetComponent<EzAnimator>().enabled = rise;
            if (!rise)
            {
                if (_object.GetComponent<CharacterJoint>())
                {
                    _object.GetComponent<CharacterJoint>().massScale = 0;
                    _object.GetComponent<CharacterJoint>().connectedMassScale = 0;
                    //_object.GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = false;
                    //_object.GetComponent<CharacterJoint>().enableCollision = false;
                    _object.GetComponent<CharacterJoint>().enablePreprocessing = false;
                    _object.GetComponent<CharacterJoint>().enableProjection = false;
                    //_object.GetComponent<Rigidbody>().AddForce(Vector3.up * 100f);// = false;
                }
            }
            else
            {
                if (_object.GetComponent<CharacterJoint>())
                {
                    _object.GetComponent<CharacterJoint>().massScale = 10;
                    _object.GetComponent<CharacterJoint>().connectedMassScale = 10;
                    //_object.GetComponent<CharacterJoint>().autoConfigureConnectedAnchor = true;
                    //_object.GetComponent<CharacterJoint>().enableCollision= true;
                    _object.GetComponent<CharacterJoint>().enablePreprocessing = true;
                    _object.GetComponent<CharacterJoint>().enableProjection = true;
                    //_object.GetComponent<Rigidbody>().AddForce(Vector3.up * 100f);
                }
            }
        }
        GameObject kyle = null;
        if (GameObject.Find("Robot Kyle"))
            kyle = GameObject.Find("Robot Kyle");
        if (kyle.GetComponent<IK_Test>())
        {
            kyle.GetComponent<IK_Test>().enabled = !rise;
        }
        if (kyle.GetComponent<Animator>())
        {
            kyle.GetComponent<Animator>().enabled = !rise;
        }
        if (kyle.GetComponent<CharacterController>())
        {
            kyle.GetComponent<CharacterController>().enabled = !rise;
        }
        if (kyle.GetComponent<EzAnimator>())
        {
            kyle.GetComponent<EzAnimator>().enabled = !rise;
        }
        if (kyle.GetComponent<EzMotor>())
        {
            kyle.GetComponent<EzMotor>().enabled = !rise;
        }
        if (kyle.GetComponent<CapsuleCollider>())
        {
            kyle.GetComponent<CapsuleCollider>().enabled = false;// !rise;
        }

        if (GameObject.Find("AnimatedPlayerController"))
        {
            if (GameObject.Find("AnimatedPlayerController").GetComponent<EzPlayerController>())
                GameObject.Find("AnimatedPlayerController").GetComponent<EzPlayerController>().enabled = !rise;
        }
    }


        private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Rise_Death(true);
        if (Input.GetKeyDown(KeyCode.R))
            Rise_Death(false);
    }
    void Components(Transform _weapon, bool show)
    {
        if (_weapon.GetComponent<BoxCollider>())
            _weapon.GetComponent<BoxCollider>().enabled = show;
        if (_weapon.GetComponent<CapsuleCollider>())
            _weapon.GetComponent<CapsuleCollider>().enabled = show;
    }
}
