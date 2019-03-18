using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] GameObject _weapon;
    [SerializeField] public float hitSpeed;
    [SerializeField] public float damage;


    void Start()
    {
        _weapon = this.gameObject;
    }
}
