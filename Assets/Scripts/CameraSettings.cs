using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public Transform floor;
    public float initialZ = -20f; 
    public float targetZ = -17f; 
    public float smoothSpeed = 2f; 
    private bool isZooming = true;

    void Start()
    {
        if (floor != null)
        {
            transform.position = new Vector3(0, floor.position.y, initialZ);
        }
        else
        {
            Debug.LogError("El objeto Floor no está asignado en CameraSettings.");
        }
    }

    void Update()
    {
        if (floor != null)
        {
            if (isZooming)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, floor.position.y, targetZ), Time.deltaTime * smoothSpeed);

                if (Mathf.Abs(transform.position.z - targetZ) < 0.01f)
                {
                    isZooming = false; 
                }
            }
            else
            {
                Vector3 targetPosition = new Vector3(0, floor.position.y, targetZ);
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
            }
        }
    }
}
