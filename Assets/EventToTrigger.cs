using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventToTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    //public float upward = 200f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bounce(float force)
    {
        rb.AddForce(0, force, 0);
    }
}
