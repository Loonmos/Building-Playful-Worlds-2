using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public CharacterController charController;

    public Transform starCrystal;
    public Transform crystalHoldPoint;
    public Transform starRegular;
    public Transform tpTransform;
    
    private float lerpSpeed = 5f;
    
    public bool canUse;
    private bool positioning;

    public int uses;
    
    void Start()
    {
        charController.enabled = true;

        canUse = true;
        positioning = false;
        uses = 1;
    }

    
    void Update()
    {
        if (Input.GetButton("LowG") && canUse == true && uses >= 1)
        {
            positioning = true;
            Debug.Log("abilityUsing");

            Vector3 newPos = Vector3.Lerp(starCrystal.position, crystalHoldPoint.position, Time.deltaTime * lerpSpeed);
            starCrystal.position = newPos;

            tpTransform.position = starCrystal.position;
        }

        if (Input.GetButtonUp("LowG") && positioning == true)
        {
            positioning = false;
            Debug.Log("abilityRelease");

            charController.enabled = false;
            transform.position = tpTransform.position;
            charController.enabled = true;

            starCrystal.position = starRegular.position;

            uses = 0;
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
