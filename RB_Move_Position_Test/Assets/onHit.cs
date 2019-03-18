using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onHit : MonoBehaviour
{
    Slider healthBar;
    Text _name;
    float hitCount = 0;
    Animator animator;

    float health = 100;
    float healthNow;

    private void Start()
    {
        if (GetComponentInChildren<Slider>())
        healthBar = GetComponentInChildren<Slider>();
        _name = GetComponentInChildren<Text>();
        _name.text = transform.name;

        if (GameObject.Find("Robot Kyle") && GameObject.Find("Robot Kyle").GetComponent<Animator>())
        animator = GameObject.Find("Robot Kyle").GetComponent<Animator>();
        healthNow = health;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (animator != null && healthNow > 0)
        {
            float damageMultiply;
            damageMultiply = animator.GetFloat("Damage");
            //Debug.Log(damageMultiply);
            //Debug.Log(collision.transform.name);
            
            if (collision.transform.GetComponent<weapon>() && damageMultiply > 0)
            {
                float damage = ((collision.transform.GetComponent<weapon>().damage * damageMultiply) / health) * 100f;

                healthNow -= damage;

                if (healthNow > 0)
                {
                    healthBar.value = (healthNow / health) * 100f;
                   // Debug.Log("HIT " + collision.transform.name);
                }
                else
                {
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    GetComponent<Rigidbody>().useGravity = true;
                    healthBar.value = 0;
                }
            }
        }
    }
}
