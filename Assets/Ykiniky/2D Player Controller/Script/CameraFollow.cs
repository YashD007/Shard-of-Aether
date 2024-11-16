using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffSet = 1f;
    public Transform Target;

    // camera will follow a player 
    void Update()
    {
        Vector3 newPos = new Vector3(Target.position.x, Target.position.y + yOffSet, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}