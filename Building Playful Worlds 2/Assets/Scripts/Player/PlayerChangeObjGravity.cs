using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeObjGravity : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private float pickupDistance = 7f;
    [SerializeField] private LayerMask pickupLayerMask;

    private ObjectGrabbable objectGrabbable;

    public Transform starCrystal;
    public Transform starRegular;
    public Transform starCastObj;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("FocusOther"))
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) // if the raycast hits an object with the script
                {
                    starCrystal.position = starCastObj.position;
                    objectGrabbable.ChangeObjGravity();
                }
            }
        }
    }
}
