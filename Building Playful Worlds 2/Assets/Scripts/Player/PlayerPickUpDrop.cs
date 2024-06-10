using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    public PlayerMovement playerMove;
    public ThirdPersonMovement thirdMove;
    public PlayerAudio playerAudio;
    public StarCrystalActive starCrystal;

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform grabPoint;

    private ObjectGrabbable objectGrabbable;

    private float pickupDistance = 5f;
    [SerializeField] private float scroll = 0;
    public float scrollValue;
    [SerializeField] private bool isHoldingSmt = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // press left mouse button to pick up or drop
        {
            if (objectGrabbable == null) // not carrying an object, try to grab
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable)) // if the raycast hits an object with the script
                    {
                        playerMove.canChangeGravSelf = false;
                        //thirdMove.canChangeGravSelf = false;
                        objectGrabbable.Grab(grabPoint); // object is picked up
                        objectGrabbable.pickedUp = true;
                        isHoldingSmt = true;

                        playerAudio.pickUpVase.Play();
                        starCrystal.ChangeGrav();
                    }
                }
            }
            else // currently carrying smt, drop
            {
                playerMove.canChangeGravSelf = true;
                //thirdMove.canChangeGravSelf = true;
                objectGrabbable.pickedUp = false;
                objectGrabbable.Drop(); // object is dropped
                isHoldingSmt = false;
                objectGrabbable = null;
                
                playerAudio.pickUpVase.Stop();
                playerAudio.pickUpVase.Play();
                starCrystal.SetNormal();
            }
        }

        //if (isHoldingSmt == true)
        //{
        //    ChangeObjectGrav();
        //}
    }

    void ChangeObjectGrav()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            scroll += scrollValue;
            // change starcrystal pos
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            scroll -= scrollValue;
            // change starcrystal pos
        }

        if (scroll >= 1)
        {
            scroll = 1;
            objectGrabbable.SetGravHigh();
        }

        if (scroll == 0)
        {
            objectGrabbable.SetGravNormal();
        }

        if (scroll <= -1)
        {
            scroll = -1;
            objectGrabbable.SetGravLow();
        }
    }
}
