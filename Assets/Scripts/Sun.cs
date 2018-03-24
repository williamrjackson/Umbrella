using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    public GameOver gameOver;
	// Update is called once per frame
	void Update () {
		//TODO: Make eyes look at umbrella
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<UmbrellaCtrl>())
        {
            print("Sun");
            gameOver.DoGameOver();
        }
    }
}
