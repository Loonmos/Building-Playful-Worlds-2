using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public UnityEvent ActivateScreen;

    public GameObject tutorialScreen;
    public TMP_Text text;

    public float tutorialTime = 5f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
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
        StartCoroutine(SetActive());
        text.SetText(message);
    }

    public IEnumerator SetActive()
    {
        tutorialScreen.SetActive(true);

        yield return new WaitForSeconds(tutorialTime);

        tutorialScreen.SetActive(false);
    }
}
