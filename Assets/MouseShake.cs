using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShake : MonoBehaviour
{
    public Rigidbody rb;
    public bool shake;
    public float upwardForce;
    Vector2 oldMouseAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        // shake = Mathf.Sign(mouseAxis.x) != Mathf.Sign(this.oldMouseAxis.x) ||
        //             Mathf.Sign(mouseAxis.y) != Mathf.Sign(this.oldMouseAxis.y);
        // oldMouseAxis = mouseAxis;
        //if (this.shake) Debug.Log(Time.time);
        // Debug.Log(Input.GetAxis("Mouse X"));
        //Debug.Log(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        if (shake)
        {
            rb.AddForce(upwardForce * Time.deltaTime, 0, 0);
        }
    }
}
