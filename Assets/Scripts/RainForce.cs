using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainForce : MonoBehaviour {
    [Range(0f, 15f)]
    public float m_RainStrength = 11f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        coll.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * -m_RainStrength);
    }
}
