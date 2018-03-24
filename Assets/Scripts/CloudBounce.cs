using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBounce : MonoBehaviour {
    public float m_bounceStrength=4f;
	
    void OnCollisionEnter2D(Collision2D coll)
    {
        Rigidbody2D rigidBody;
        if (rigidBody = coll.gameObject.GetComponent<Rigidbody2D>())
        {
            // Bounce "Away"...
            // Direction is from center to contact point;
            Vector3 direction = new Vector3(coll.contacts[0].point.x, coll.contacts[0].point.y, 0f) - transform.position;
            rigidBody.AddForce(direction * m_bounceStrength, ForceMode2D.Impulse);
        }
    }
}
