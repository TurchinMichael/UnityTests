using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_move : MonoBehaviour
{
    Rigidbody rb;
    CharacterController controller;
    [SerializeField] float speed;
    private Vector3 moveDirection = Vector3.zero;
    public float jumpSpeed = 8.0F; //Начальная скорость прыжка
    public float gravity = 20.0F; //Сила гравитации
    float distToGround;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        if (GetComponent<CharacterController>())
            controller = GetComponent<CharacterController>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
    bool doubleJump;
    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();

        if (rb != null)
        {
            Debug.Log("RB");
            float x = Input.GetAxis("Horizontal"), z = Input.GetAxis("Vertical");
            //if (IsGrounded())

            Vector3 movement;
            //rb.velocity.Set(rb.velocity.x, 0, rb.velocity.z);
            if (IsGrounded())
            {
                //jumpSpeed = 0;
            }

            if (IsGrounded() && Input.GetButtonDown("Jump")) //Если мы нажимаем пробел
            {
                //jumpSpeed = 1;
                //rb.velocity.Set(rb.velocity.x, jumpSpeed, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpSpeed);
            }


            if (!IsGrounded() && Input.GetButtonDown("Jump") && !doubleJump)
            {
                rb.AddForce(Vector3.up * jumpSpeed);
                doubleJump = true;
            }

            Debug.Log(jumpSpeed);


            movement = new Vector3(x * speed, 0, z * speed);
            // rb.velocity.y = jumpSpeed;
            //jumpSpeed = 1.0F;

            rb.MovePosition(transform.position + movement);
        }
        if (controller != null)
        {
            if (controller.isGrounded)
            { //В нем есть переменная, которая дает знать, стоит ли он на земле. И если он стоит...
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Берем значения кнопок WASD или стрелочек и создаем вектор, указывающий в нужную сторону
                moveDirection = transform.TransformDirection(moveDirection); //Переводим локальные координаты в соответствующие глобальные
                moveDirection *= speed; //moveDirection - это коэффициент скорости. Поэтому мы умножаем его на максимальную скорость, чтобы получить текущую
                if (Input.GetButton("Jump")) //Если мы нажимаем пробел
                    moveDirection.y = jumpSpeed; //Мы придаем скорости прыжка
            }
            moveDirection.y -= gravity * Time.deltaTime; //Это действие гравитации
            controller.Move(moveDirection * Time.deltaTime); //И получив все данные в конце-концов мы вызываем переменную Move и даем ей наш вектор направления. И она сама будет двигать нашего персонажа как надо. Без прохождений сквозь стены, без addForce и прочей ереси.
        }
    }


    //void OnCollisionEnter(Collision collision)
    //{
    //    foreach (ContactPoint contact in collision.contacts)
    //    {
    //        Debug.DrawRay(contact.point, contact.normal, Color.green, 2, false);
    //    }
    //}


    //void OnCollisionStay(Collision collision)
    //{
    //    foreach (ContactPoint contact in collision.contacts)
    //    {
    //        Debug.DrawRay(contact.point, contact.normal, Color.green, 2, false);
    //    }
    //} 

    RaycastHit hit;
    bool IsGrounded()
    {
        bool st;
        Ray _ray = new Ray(transform.position, Vector3.down);

        st = false;
        if (Physics.Raycast(_ray, out hit, distToGround + 0.01f/*Mathf.Infinity*/))
        {
            st = true;
            doubleJump = false;
        }

        Physics.Raycast(_ray, out hit, Mathf.Infinity);
        Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
        //Debug.Log("distToGround " + distToGround + 0.1f + " groud " + st);
        return st; //  Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
