using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlScript : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 18.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Animation animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animation>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Probuje skoczyc");
                moveDirection.y = jumpSpeed;
              animator.Play("jump0");
             
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
