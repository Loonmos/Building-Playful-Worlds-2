using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTemple : MonoBehaviour
{
    public List<GameObject> crystalList = new List<GameObject>();
    [SerializeField] private bool crystalsActive;

    public Animator anim1;
    public Animator anim2;

    private void Start()
    {
        anim1.SetBool("Open", false);
        anim2.SetBool("Open", false);
    }

    public void OpenDoors()
    {
        anim1.SetBool("Open", true);
        anim2.SetBool("Open", true);
    }

    public void CheckCrystals()
    {
        foreach (GameObject crystal in crystalList)

            if (crystal.activeInHierarchy == false)
            {
                crystalsActive = false;
                break;
            }
            else
            {
                crystalsActive = true;
            }

        if (crystalsActive == true)
        {
            OpenDoors();
        }
    }
}
