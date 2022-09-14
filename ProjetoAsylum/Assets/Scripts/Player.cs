using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController con;
    Animator Anim;
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;
   
    public float forwardspeed = 4f;
    
    private float strafespeed = 4f;

    private float gravity;
    private float jumpSpeed;
    
    public float maxHighJump = 3f;
   
    public float timeToMaxHighJump = 0.5f;

    private bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   
        con = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        gravity = (-2 * maxHighJump) / (timeToMaxHighJump * timeToMaxHighJump);
        jumpSpeed = (2 * maxHighJump) / timeToMaxHighJump;
    }




    // Update is called once per frame
    void Update()
    {


        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxis("Vertical") != 0)
        {
            isWalking = true;
            Anim.SetInteger("state", 1);
        }
        else
        {
            isWalking = false;
            Anim.SetInteger("state", 0);
        }


        forward = forwardInput * forwardspeed * transform.forward;
        strafe = strafeInput * strafespeed * transform.right;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            forwardspeed = 7f;
            Anim.SetInteger("state", 2);

        }
        else
        {

            forwardspeed = 4f;
            if (isWalking == true)
            {
                Anim.SetInteger("state", 1);
            }
            else
            {
                Anim.SetInteger("state", 0);
            }



        }

        vertical += gravity * Time.deltaTime * Vector3.up;
        if (con.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && con.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
            Anim.SetInteger("state", 3);
        }
        else
        {

        }
        if (vertical.y > 0 && (con.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        Vector3 velocidadeFinal = forward + strafe + vertical;
        con.Move(velocidadeFinal * Time.deltaTime);
    }

}
