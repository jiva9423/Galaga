using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Realtime;
using Photon.Pun;

public class Movement : MonoBehaviourPun, IPunObservable
{
    Vector3 pos;
    float speed;
    float vDirection;
    float hDirection;
    public GameObject holder;
    PlayerControls controls;
    public GameObject bullet;
    // Start is called before the first frame update

    private void Awake()
    {
        // check if the view im on is mine.
        if (!photonView.IsMine)
        {
            Destroy(transform.Find("Hologram Pyramid").gameObject);
            Destroy(transform.Find("Main Camera").gameObject);
            //transform.Find("Holder").gameObject.SetActive(false);
            //transform.Find("Hologram Pyramid").gameObject.SetActive(false);
            //transform.Find("Main Camera").gameObject.SetActive(false);
            //GetComponent<Movement>().enabled = false;
            //Destroy(GetComponent<Movement>());

        }
        else {
            // instantiate the player controls
            controls = new PlayerControls();
            //lambda ignores the value returns.


            // detects what button is being pressed and gives us a direction based on it.
            controls.Gameplay.Left.performed += ctx => hDirection = RightValue();
            controls.Gameplay.Right.performed += ctx => hDirection = LeftValue();
            controls.Gameplay.Up.performed += ctx => vDirection = UpValue();
            controls.Gameplay.Down.performed += ctx => vDirection = DownValue();
            controls.Gameplay.Shooting.performed += ctx => Shoot();
            controls.Gameplay.Left.canceled += ctx => hDirection = 0;
            controls.Gameplay.Right.canceled += ctx => hDirection = 0;
            controls.Gameplay.Up.canceled += ctx => vDirection = 0;
            controls.Gameplay.Down.canceled += ctx => vDirection = 0;
        }

        
    }


    void Start()
    {
        pos = this.transform.position;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            MoveShip(); // this moves the player ship
        }
    }

    // returns value to make plane move left
    int LeftValue() {
        return -1;
    }

    // returns value to make plane move right
    int RightValue()
    {
        return 1;
    }


    // returns value to make plane move down
    int DownValue()
    {
        return -1;
    }

    // returns value to make plane move up
    int UpValue()
    {
        return 1;
    }


    // this applies the movement.
    void MoveShip() {

        // applies movement from controller input
        pos.x += speed * Time.deltaTime * hDirection;
        pos.y += speed * Time.deltaTime * vDirection;
        if (hDirection == 1) {
            //rotate left
            
            holder.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 15);
            //rotate right
        }
        else if (hDirection == -1)
        {
            //rotate plane left
            holder.transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, -15);
        }
        else {
            
            //keep plane flat
            holder.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        transform.position = pos;
    }


    // Instantiate a bullet
    void Shoot() {
        GameObject bulletI = Instantiate(bullet);
        Vector3 pos = transform.position;
        pos.z += 1.9f;
        bulletI.transform.position = pos;
        Debug.Log("Ship moved = " + photonView.name + " " + photonView.ViewID);
    }

    // enable the controller
    public void OnEnable()
    {
        if (controls != null) {
            controls.Gameplay.Enable();
        }
        
    }

    //disable the controller
    public void OnDisable()
    {
        if(controls != null)
        {
            controls.Gameplay.Disable();
        }
        
    }

    // Send position of planes to PUN server to update on every client
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            pos = (Vector3)stream.ReceiveNext();
        } 
    }
}
