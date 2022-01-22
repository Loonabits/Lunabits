using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    [SerializeField] [Range(0.01f, 1f)]
    private float smoothSpeed = 0.125f;

    [SerializeField]
    private Vector3 offset;

    private Vector3 velocity = Vector3.zero;


    void LateUpdate()
    {
        Vector3 dPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, dPosition, ref velocity, smoothSpeed);
    }
}
