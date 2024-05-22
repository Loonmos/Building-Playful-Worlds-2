using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrystalAndInsert : MonoBehaviour
{
    public PlayerInventory playerInventory;

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask crystalLayerMask;
    [SerializeField] private LayerMask insertLayerMask;

    private CrystalGrabbable crystalGrabbable;
    private InsertCrystal insertCrystal;
    private float pickupDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("QKey"))
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, crystalLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out crystalGrabbable)) // if the raycast hits a crystal with the script
                {
                    crystalGrabbable.PickUpCrystal();
                }
            }

            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHitHit, pickupDistance, insertLayerMask))
            {
                if (raycastHitHit.transform.TryGetComponent(out insertCrystal)) // if the raycast hits the insert place with the script
                {
                    insertCrystal.CrystalInserted();
                }
            }
        }


            
    }
}
