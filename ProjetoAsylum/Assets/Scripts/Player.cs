using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Player : MonoBehaviour
{
    private CharacterController con;
    public PhotonView View;
    public Boolean[] chaves;
    Animator Anim;
    
    public Transform CharacterBody;
    public Transform Head;

    int hitCount;
    
    Vector3 forward;
    Vector3 strafe;
    public Vector3 vertical;

    private bool podePular = true;

    public float forwardInput;
    public float strafeInput;

    public Vector3 velocidadeFinal;

    private float rotationX = 0;
    private float rotationY = 0;

    public float sensitivityX = 2.5f;
    public float sensitivityY = 2.5f;

    private float angleYmin = -45;
    private float angleYmax = 45;

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
        vertical = Vector3.zero;
        Head.gameObject.SetActive(View.IsMine);
        chaves = new Boolean[4];
        chaves[0] = false;
        chaves[1] = false;
        chaves[2] = false;
        chaves[3] = false;
    }




    // Update is called once per frame
    void Update()
    {
        if (View.IsMine)
        {
            

            float hori = Input.GetAxisRaw("Mouse Y") * sensitivityY;
            float vert = Input.GetAxisRaw("Mouse X") * sensitivityX;

            rotationX += vert;
            rotationY += hori;

            rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

            CharacterBody.localEulerAngles = new Vector3(0, rotationX, 0);

            Head.localEulerAngles = new Vector3(-rotationY, 0);

             forwardInput = Input.GetAxis("Vertical");
             strafeInput = Input.GetAxis("Horizontal");

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

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0)
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

            if (gameObject.tag == "Player")
            {


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

               
            }

            
            velocidadeFinal = forward + strafe + vertical;
            con.Move(velocidadeFinal * Time.deltaTime);

            if (gameObject.tag == "Mob")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Anim.SetInteger("state", 3);

                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Ataque());

            if (hitCount == 2)
            {
                Anim.SetInteger("state", 3);
                Debug.Log("PlayerMorto");
            }

        }
    }
    
    IEnumerator Ataque() 
    {
        Debug.Log(hitCount);
        hitCount++;
        Debug.Log(hitCount);
        yield return new WaitForSeconds(15);
    }

   

}
