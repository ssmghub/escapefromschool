using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHandActions : MonoBehaviour
{
    //left hand
    GameObject heldObject = null;
    public Transform handPosition;
    public LayerMask layerMask; 

    // private bool canGrab = false;

    bool canDrop = false;
    public float dropRate = 2.0f; 

    //right hand
    public GameObject shot;
    public Transform shotTransform;
    public float fireRate = 0.2f;
    private float nextFire = 0.0f;

    public static int bulletNumDefault = 50;
    public static int currentBulletNum = 0; // http://t.csdn.cn/pdhoL


    // Start is called before the first frame update
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentBulletNum = bulletNumDefault; 
    }

    List<bool> onBtClickList; 

    // Update is called once per frame
    public void Update()
    {
        onBtClickList = new List<bool>();
        onBtClickList.Add(InventoryItemClickable.onButton);
        onBtClickList.Add(ExitClickable.onButton);
        onBtClickList.Add(StopClickable.onButton);

        //判断是否点击在UI上: Reference: https://blog.csdn.net/wswnbtfkpuqw/article/details/125621482
        if (Input.GetButton("Fire1") && Time.time > nextFire && currentBulletNum > 0)
        {
            if(!onBtClickList.Contains(true) && Time.timeScale != 0) // if no UI button click --> Fire
            // if(!InventoryItemClickable.onButton)
            // if(!EventSystem.current.IsPointerOverGameObject())
            {
                nextFire = Time.time + fireRate;
                Instantiate(
                    shot,
                    shotTransform.position,
                    Camera.main.transform.rotation);
                
                PlayerHandActions.currentBulletNum -= 1; 

                Cursor.lockState = CursorLockMode.Locked;
            }
                // Cursor.lockState = CursorLockMode.Locked;
        }
       
        // Grab Action
        if (Input.GetKeyDown(KeyCode.E)) //mouse left key
        {
            if (heldObject == null)
            {
                RaycastHit colliderHit; 
                if (Physics.Raycast(transform.position, 
                    transform.forward, 
                    out colliderHit, 
                    10.0f, 
                    layerMask))
                {
                    heldObject = colliderHit.collider.gameObject;
                    heldObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }

        // Drop Action
        if (Input.GetKeyDown(KeyCode.Q))
        {
            canDrop = true;
        }

    }

    private void FixedUpdate()
    {
        if(heldObject != null)
        {
            // move the thing we're holding
            heldObject.GetComponent<Rigidbody>().MovePosition(handPosition.position); //Position
            heldObject.GetComponent<Rigidbody>().MoveRotation(handPosition.rotation); //Rotation

            if(canDrop)
            {
                canDrop = false;

                heldObject.GetComponent<Rigidbody>().AddForce(transform.forward * dropRate, ForceMode.Impulse);
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject = null;
            }
        }
    }

}
