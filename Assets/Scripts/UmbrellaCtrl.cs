using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaCtrl : MonoBehaviour {

    public float m_fRotateAmount = 3f;
    public float m_fSpeedLimit = 5f;
    public SpriteRenderer umbrella;
    public SpriteRenderer wind;
    public Camera mainCamera;
    public GameOver gameOver;

    Rigidbody2D m_RigidBody;
    float m_fCurrentZRotation = 0;
    bool m_isBlowing = false;
    bool m_isRotatingLeft = true;

	// Use this for initialization
	void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();

        gameOver.GameOverEvent += RegisterGameOver;
	}
	
    void RegisterGameOver()
    {
        Rest();
    }

    // Update is called once per frame
    void Update () {
        if (!gameOver.IsGameOver())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Blow();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                Rest();
            }
            if (!IsVisible())
            {
                print("Offscreen");
                gameOver.DoGameOver();
            }
        }
    }
    void LateUpdate()
    {
        if (m_isBlowing)
        {
            if (m_RigidBody.velocity.magnitude < m_fSpeedLimit)
            {
                print(m_RigidBody.velocity.magnitude);
                m_RigidBody.AddForce(transform.up * 10);
            }
        }
        else
        {
            if (m_fCurrentZRotation > 45f)
            {
                m_isRotatingLeft = false;
            }
            else if (m_fCurrentZRotation < -45f)
            {
                m_isRotatingLeft = true;
            }
            if (m_isRotatingLeft)
            {
                m_fCurrentZRotation += m_fRotateAmount * Time.deltaTime;
            }
            else
            {
                m_fCurrentZRotation -= m_fRotateAmount * Time.deltaTime;
            }
            transform.eulerAngles = new Vector3(0, 0, m_fCurrentZRotation);
        }

    }
    void Blow()
    {
        m_isBlowing = true;
        m_RigidBody.velocity = Vector2.zero;
        m_RigidBody.freezeRotation = true;
        wind.enabled = true;
    }

    void Rest()
    {
        m_isBlowing = false;
        m_RigidBody.freezeRotation = false;
        if (m_fCurrentZRotation > 0f)
        {
            m_isRotatingLeft = false;
        }
        else
        {
            m_isRotatingLeft = true;
        }
        wind.enabled = false;
    }

    bool IsVisible()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        if (GeometryUtility.TestPlanesAABB(planes, GetComponent<BoxCollider2D>().bounds))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
