using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the camera follow the player
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField]private float leftLimit;
    [SerializeField]private float rightLimit;
    [SerializeField]private float speed;
    
    void Update()
    {
        Vector3 targetPosition =  PlayerController.instance.transform.position.x * Vector3.right;

        if (targetPosition.x<leftLimit){
            targetPosition = leftLimit * Vector3.right;
        }
        if (targetPosition.x>rightLimit){
            targetPosition = rightLimit * Vector3.right;
        }

        targetPosition.z = transform.position.z;

       transform.position = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime*speed);
    }
}
