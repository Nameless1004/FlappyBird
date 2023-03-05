using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool UseLerp = false;
    public Transform target; // The object that the camera should follow
    public float smoothing = 5f; // The speed at which the camera follows the target
    public Vector3 offset; // The offset between the camera and the target
    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        // Calculate the target position with the offset
        Vector3 targetPosition = target.position + offset;

        // Move the camera towards the target position using smoothing
        if (UseLerp)
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothing);
        }
    }
}
