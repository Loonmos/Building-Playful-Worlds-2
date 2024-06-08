using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public UnityEvent ActivateScreen;

    public GameObject destroyAfter;
    public GameObject tutorialScreen;
    public TMP_Text text;

    //public float tutorialTime = 5f;
    public bool tutorialVisible;
    
    void Start()
    {
        tutorialVisible = false;
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
