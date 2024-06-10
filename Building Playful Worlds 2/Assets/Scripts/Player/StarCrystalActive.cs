using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCrystalActive : MonoBehaviour
{
    private GameManager gameManager;
    public bool starActive;
    public Animator anim;

    public GameObject changeSelfPos;
    public GameObject normalPos;
    public int lerpSpeed;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.levelCompleted == true)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        transform.position = normalPos.transform.position;
    }

    public void TurnOn()
    {
        this.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }

    public void ChangeGrav()
    {
        //Vector3 newPos = Vector3.Lerp(transform.position, changeSelfPos.transform.position, Time.deltaTime * lerpSpeed);
        //transform.position = newPos;
        transform.position = changeSelfPos.transform.position;
    }

    public void SetNormal()
    {
        transform.position = normalPos.transform.position;
    }

    public void Anim()
    {
        StartCoroutine(ChangeAnimation());
    }

    public IEnumerator ChangeAnimation()
    {
        //anim.SetBool("Change", true);

        yield return new WaitForSeconds(0.5f);

        //anim.SetBool("Change", false);
    }
}
