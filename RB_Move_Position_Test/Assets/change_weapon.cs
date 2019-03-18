using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_weapon : MonoBehaviour
{
    [SerializeField] List<weapon> weapons;
    [SerializeField] Animator _animator;
    clothColliders clothCol;
    int number;

    private void Start()
    {
        foreach (weapon child in GetComponentsInChildren<weapon>())
        {
            weapons.Add(child);
            Components(child.transform, false);
        }
        clothCol = GameObject.Find("cloth").GetComponent<clothColliders>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //clothCol.AddCollider(weapons);
            Components(weapons[number].transform, false);
            foreach (Transform child in weapons[number].GetComponentsInChildren<Transform>())
            {
                Components(child, false);
            }

            number = (number == weapons.Count - 1) ? 0 : number + 1;

            Components(weapons[number].transform, true);
            foreach (Transform child in weapons[number].GetComponentsInChildren<Transform>())
            {
                Components(child, true);
            }

            if (weapons[number].GetComponent<CapsuleCollider>())
            {
                clothCol.AddCollider(weapons[number].GetComponent<CapsuleCollider>());
            }

            _animator.SetFloat("hit_Speed", weapons[number].hitSpeed);
        }
    }

    void Components(Transform _weapon, bool show)
    {
        if (_weapon.GetComponent<BoxCollider>())
            _weapon.GetComponent<BoxCollider>().enabled = show;
        if (_weapon.GetComponent<CapsuleCollider>())
            _weapon.GetComponent<CapsuleCollider>().enabled = show;
        if (_weapon.GetComponent<Renderer>())
            _weapon.GetComponent<Renderer>().enabled = show;
    }
}

