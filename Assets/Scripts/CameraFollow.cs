using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour { 
    public Transform followee;
    private Vector2 m_Offset;
    public float smoothTime = 0.3F;

    private float fHighestPos;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
    }

    // Use lateupdate to ensure positioning of sphere is complete
    void LateUpdate () {
        // Move to new poition
        fHighestPos = Mathf.Max(fHighestPos, transform.position.y);
        Vector3 targetPosition = new Vector3(0, Mathf.Max(followee.position.y, fHighestPos), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
