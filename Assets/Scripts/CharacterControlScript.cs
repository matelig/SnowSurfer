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
    private float rotate = 0;
    public bool collided = false;
    private GameScript gameScript;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animation>();
        GameObject game = GameObject.Find("GameController");
        gameScript = game.GetComponent<GameScript>();
    }

    void Update()
    {
        if (!gameScript.isPaused)
        {
            CharacterController controller = GetComponent<CharacterController>();

            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                moveDirection *= speed;
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("Probuje skoczyc");
                    moveDirection.y = jumpSpeed;
                    animator.Play("Armature|jump");

                }
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            if (!collided)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    if (rotate < 30)
                        rotate += 2;
                    transform.rotation = Quaternion.Euler(0, rotate, 0);
                }
                else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    if (rotate > -30)
                        rotate -= 2;
                    transform.rotation = Quaternion.Euler(0, rotate, 0);
                }
                else
                {
                    rotate = Mathf.Lerp(rotate, 0, 0.15f);
                    transform.rotation = Quaternion.Euler(0, rotate, 0);
                }
            }
        }
    }
}
