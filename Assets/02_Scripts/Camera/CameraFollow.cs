using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, -5f, -2);
    public float smoothSpeed = 5f;

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + player.rotation * offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            transform.LookAt(player.position);
        }
    }
}
