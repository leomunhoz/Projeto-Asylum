using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCamera : MonoBehaviour
{
    public Transform CharacterBody;
    public Transform CharacterHead;

    public PhotonView View;

   



    private float rotationX = 0;
    private float rotationY = 0;

    public float sensitivityX = 0.5f;
    public float sensitivityY = 0.5f;

    private float angleYmin = -45;
    private float angleYmax = 45;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnValidate()
    {
        if (CharacterBody == null) CharacterBody = GetComponent<Transform>();
        if (CharacterHead == null) CharacterHead = GetComponent<Transform>();
    }


    private void LateUpdate()
    {


        if (View.IsMine)
        {
            transform.position = CharacterHead.position;
        }





    }

    // Update is called once per frame
    void Update()
    {
        if (View.IsMine)
        {

            float horizontal = Input.GetAxisRaw("Mouse Y") * sensitivityY;
            float vertical = Input.GetAxisRaw("Mouse X") * sensitivityX;

            rotationX += vertical;
            rotationY += horizontal;

            rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

            CharacterBody.localEulerAngles = new Vector3(0, rotationX, 0);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


        }
    }
}
