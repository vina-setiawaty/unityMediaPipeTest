using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            movement.enabled = false;
        }
    }
}
