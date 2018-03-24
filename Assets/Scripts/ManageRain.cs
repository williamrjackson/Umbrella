using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageRain : MonoBehaviour
{
    public RainForce m_RainObject;
    public float m_fRainDuration;

    // Use this for initialization
    void Start()
    {
        m_RainObject.gameObject.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        StopCoroutine(Rain());
        StartCoroutine(Rain());
    }

    IEnumerator Rain()
    {
        m_RainObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(m_fRainDuration);
        m_RainObject.gameObject.SetActive(false);
    }
}
