using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameOver : MonoBehaviour {

    public GameObject playAgain;
    public GameObject quit;

    public UnityAction GameOverEvent;

    private bool gameIsOver = false;
	// Use this for initialization
	void Start () {
        playAgain.SetActive(false);
        quit.SetActive(false);
	}
	
    public bool IsGameOver()
    {
        return gameIsOver;
    }


    public void DoGameOver()
    {
        gameIsOver = true;
        if (GameOverEvent != null)
            GameOverEvent();
        print("Game Over");
        playAgain.SetActive(true);
        quit.SetActive(true);

    }
}
