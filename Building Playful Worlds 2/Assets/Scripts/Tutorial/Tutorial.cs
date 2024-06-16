using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public UnityEvent ActivateScreen;
    public GameManager gameManager;

    public GameObject destroyAfter;
    public GameObject tutorialScreen;
    public TMP_Text text;

    //public float tutorialTime = 5f;
    public bool tutorialVisible;
    public bool inTemple;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        tutorialVisible = false;

        if (gameManager.levelCompleted == true && inTemple == false)
        {
            gameObject.SetActive(false);
        }
    }

    
    void Update()
    {
        if (tutorialVisible == true && Input.GetMouseButtonDown(1))
        {
            tutorialVisible = false;
            tutorialScreen.SetActive(false);
            Destroy(destroyAfter); //we dont need the tutorial part again
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivateScreen.Invoke();
        }
    }

    public void MessagePopUp(string message)
    {
        tutorialVisible = true;
        tutorialScreen.SetActive(true);
        text.SetText(message);
    }

    //public IEnumerator SetActive()
    //{
    //    tutorialScreen.SetActive(true);

    //    yield return new WaitForSeconds(tutorialTime);

    //    tutorialScreen.SetActive(false);
    //}
}
