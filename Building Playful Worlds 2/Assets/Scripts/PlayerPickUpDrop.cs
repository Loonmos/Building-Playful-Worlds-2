using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform grabPoint;

    private ObjectGrabbable objectGrabbable;

    private float pickupDistance = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("QKey"))
        {
            if (objectGrabbable == null) // not carrying an object, try to grab
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable)) // if the raycast hits an object with the script
                    {
                        objectGrabbable.Grab(grabPoint);
                    }
                }
            }
            else // currently carrying smt, drop
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
