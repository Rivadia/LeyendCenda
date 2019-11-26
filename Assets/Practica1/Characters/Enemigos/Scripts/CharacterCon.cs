using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCon : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Animator anim;
    private bool ataque;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        anim.SetFloat("Velocidad", moveDirection.z);

        if (moveDirection.z <-1)
        {
            transform.localScale = new Vector3(1, 1, -1);
        }
        else if (moveDirection.z > 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
       


        //if (moveDirection.z <= 0 || transform.rotation.y <= -90 || transform.rotation.y >= 90)
        //{
        //    moveDirection.z *= -speed;
        //    anim.SetFloat("Speed", moveDirection.z * speed);
        //}

        //anim.SetFloat("Speed", moveDirection.z * speed);

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    anim.SetLayerWeight(1, 1);
        //    anim.SetFloat("Run", 7);
        //}
        //else
        //{
        //    anim.SetLayerWeight(1, 0);
        //    anim.SetFloat("Run", 0);
        //}


        AtaqueNormal();
    }




    void AtaqueNormal()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ataque = true;
        }
        else
        {
            ataque = false;
        }


        anim.SetBool("AttackNormal", ataque);
    }
}
