using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseAction : MonoBehaviour
{
    public Rigidbody rb;
    public float sidewayForce = 500f;
    private bool leftClick = false;
    private bool rightClick = false;
    private bool middleClick = false;

    public UnityEvent triggerEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   

        leftClick = Input.GetMouseButton(0);
        rightClick = Input.GetMouseButton(1);
        middleClick = Input.GetMouseButton(2);

        if (leftClick && rightClick && middleClick)
        {
            // rb.AddForce(0, sidewayForce * Time.deltaTime, 0);
            triggerEvent.Invoke();
        }

    }
}
