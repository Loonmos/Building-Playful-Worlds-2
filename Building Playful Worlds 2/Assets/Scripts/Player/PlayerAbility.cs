using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public CharacterController charController;
    public PlayerMovement playerMovement;

    public Transform starCrystal;
    public Transform crystalHoldPoint;
    public Transform starRegular;
    public Transform tpTransform;
    
    public float lerpSpeed = 5f;
    public float tpSpeed = 5f;
    public float tpBuffer;
    
    public bool canUse;
    private bool positioning;
    private bool teleporting;

    public int uses;
    
    void Start()
    {
        charController.enabled = true;
        playerMovement.enabled = true;

        positioning = false;
        teleporting = false;
        uses = 1;
    }

    
    void Update()
    {
        if (Input.GetButton("Ability") && canUse == true && uses >= 1 && !Input.GetButton("FocusSelf") && !Input.GetButton("FocusOther"))
        {
            positioning = true;

            Vector3 newPos1 = Vector3.Lerp(starCrystal.position, crystalHoldPoint.position, Time.deltaTime * lerpSpeed);
            starCrystal.position = newPos1;

            tpTransform.position = starCrystal.position;
        }

        if (Input.GetButtonUp("Ability") && positioning == true)
        {
            positioning = false;

            teleporting = true;
            uses = 0;
        }

        if (teleporting == true)
        {
            charController.enabled = false;
            playerMovement.enabled = false;

            Vector3 newPos2 = Vector3.Lerp(transform.position, tpTransform.position, Time.deltaTime * tpSpeed);
            transform.position = newPos2;

            starCrystal.position = tpTransform.position;

            if (Vector3.Distance(transform.position, tpTransform.position) <= tpBuffer)
            {
                charController.enabled = true;
                playerMovement.enabled = true;
                starCrystal.position = starRegular.position;
                teleporting = false;
            }

        }
    }

    public void ResetUses()
    {
        uses = 1;
    }

    public void TurnOnAbility()
    {
        canUse = true;
    }
}
