using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject tutorialScreen;
    public TextMeshProUGUI tutText;

    public GameObject expositionScreen;
    public TextMeshProUGUI expoText;

    public enum State { Exposition1, Exposition2, WalkSprint, Jump, PickUp, End}
    public State state = State.Exposition1;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.levelCompleted == true)
        {
            gameObject.SetActive(false);
        }
    }

    
    void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
        switch (state)
        {
            case State.Exposition1: Exposition1(); break;
            case State.Exposition2: Exposition2(); break;
            case State.WalkSprint: WalkSprint(); break;
            case State.Jump: Jump(); break;
            case State.PickUp: PickUp(); break;
            case State.End: End(); break;
        }
    }

    private void Exposition1()
    {
        tutorialScreen.SetActive(true);
        ChangeTutText("Where am I?");

        ClickToContinue(State.Exposition2);
    }

    private void Exposition2()
    {
        ChangeTutText("What Happened?");

        ClickToContinue(State.WalkSprint);
    }

    private void WalkSprint()
    {
        ChangeTutText("Use WASD to walk and Left Shift to run");

        ClickToContinue(State.Jump);
    }

    private void Jump()
    {
        ChangeTutText("Use Spacebar to jump");

        ClickToContinue(State.PickUp);
    }

    private void PickUp()
    {
        ChangeTutText("You can pick up objects using Left Mouse Button");

        ClickToContinue(State.End);
        ClickToEnd();
    }

    private void End()
    {
        
    }

    private void ChangeTutText(string message)
    {
        tutText.SetText(message);
    }

    private void ChangeExpoText(string message)
    {
        expoText.SetText(message);
    }

    private void ClickToContinue(State newState)
    {
        if (Input.GetMouseButtonDown(1)) // needs a different button
        {
            state = newState;
        }
    }

    private void ClickToEnd()
    {
        if (Input.GetMouseButtonDown(1)) // needs a different button
        {
            tutorialScreen.SetActive(false);
        }
    }
}
