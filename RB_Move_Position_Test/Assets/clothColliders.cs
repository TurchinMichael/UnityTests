using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clothColliders : MonoBehaviour
{
    Cloth _cloth;
    void Start()
    {
        _cloth = GetComponent<Cloth>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AddCollider(List<weapon> weapons)
    {
        CapsuleCollider[] temp = new CapsuleCollider[1 + weapons.Count];
        temp[0] = GameObject.Find("Robot Kyle").GetComponent<CapsuleCollider>();  // т.к. пользователь должен взаимодействовать с тканью всегда
        Debug.Log(temp[0].name);
        for (int i = 0; i < weapons.Count; i++)
        {
            temp[i + 1] = weapons[i].GetComponent<CapsuleCollider>();  // т.к. пользователь должен взаимодействовать с тканью всегда
            Debug.Log(temp[i + 1].name);
        }
        _cloth.capsuleColliders = new CapsuleCollider[1 + weapons.Count];
        _cloth.capsuleColliders = temp;
    }
    public void AddCollider(CapsuleCollider weapon)
    {
        CapsuleCollider[] temp = new CapsuleCollider[2];
        temp[0] = GameObject.Find("Robot Kyle").GetComponent<CapsuleCollider>();  // т.к. пользователь должен взаимодействовать с тканью всегда
        
        temp[1] = weapon.GetComponent<CapsuleCollider>();  // т.к. пользователь должен взаимодействовать с тканью всегда

        _cloth.capsuleColliders = new CapsuleCollider[2];
        _cloth.capsuleColliders = temp;
    }
}
