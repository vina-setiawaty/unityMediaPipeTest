using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseShakeTime : MonoBehaviour
{
    private float positive;
    private float positiveY;
    private bool changed;
    private bool changedY;
    private int counter = 0;
    public UnityEvent triggerEvent;
    public int threshold = 10;
    public float xPos;
    public float yPos;
    public float timeLimit = 1;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        xPos = Input.mousePosition.x;
        yPos = Input.mousePosition.y;
        time = Time.time;
    }

    void Update()
    {
        
        if (positive != Mathf.Sign(xPos - Input.mousePosition.x))
        {
            if (!changed)
            {
                counter++;
            }
            changed = true;
        } else
        {
            changed = false;
        }
        positive = Mathf.Sign(xPos - Input.mousePosition.x);

        if (positiveY != Mathf.Sign(yPos - Input.mousePosition.y))
        {
            if (!changedY)
            {
                counter++;
            }
            changedY = true;
        }
        else
        {
            changedY = false;
        }
        positiveY = Mathf.Sign(yPos - Input.mousePosition.y);

        if (counter > threshold)
        {
            triggerEvent.Invoke();
            counter = 0;
        }

        if (Time.time - time > timeLimit)
        {
            Debug.Log(counter);
            time = Time.time;
            counter = 0;
        }

    }
}
