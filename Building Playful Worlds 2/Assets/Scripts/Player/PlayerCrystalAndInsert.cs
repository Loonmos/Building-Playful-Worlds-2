using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrystalAndInsert : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerInventory playerInventory;
    public StarCrystalActive starActive;
    public PlayerAudio playerAudio;

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask crystalLayerMask;
    [SerializeField] private LayerMask insertLayerMask;
    [SerializeField] private LayerMask starLayerMask;

    private CrystalGrabbable crystalGrabbable;
    private InsertCrystal insertCrystal;
    private float pickupDistance = 5f;

    public GameObject starCrystalPlayer;
    public GameObject starCrystalGround;
    public GameObject barrier;

    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.levelCompleted == true)
        {
            starCrystalGround.SetActive(false);
            barrier.SetActive(false);
        }
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, crystalLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out crystalGrabbable)) // if the raycast hits a crystal with the script
                {
                    crystalGrabbable.PickUpCrystal();
                    playerAudio.pickUpCrystal.Play();
                }
            }

            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHitHit, pickupDistance, insertLayerMask))
            {
                if (raycastHitHit.transform.TryGetComponent(out insertCrystal)) // if the raycast hits the insert place with the script
                {
                    insertCrystal.CrystalInserted();
                    playerAudio.insert.Play();
                }
            }

            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHitHitHit, pickupDistance, starLayerMask))
            {
                starCrystalGround.SetActive(false); 
                barrier.SetActive(false);

                playerAudio.pickUpCrystal.Play();
                playerAudio.barrier.Play();

                starActive.TurnOn();
            }
        }


            
    }
}
