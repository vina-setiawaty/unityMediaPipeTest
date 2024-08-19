using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseScroll : MonoBehaviour
{
    private float time;
    private float counter;
    public float threshold = 20f;
    public UnityEvent triggerEvent;
    public float timeLimit = 1f;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (threshold > 0)
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                counter += Input.mouseScrollDelta.y;
            }
        }

        if (threshold < 0)
        {
            if (Input.mouseScrollDelta.y < 0)
            {
                counter += Mathf.Abs(Input.mouseScrollDelta.y);
            }
        }

        if (counter > Mathf.Abs(threshold))
        {
            counter = 0;
            triggerEvent.Invoke();
        }
        
        if (Time.time - time > timeLimit)
        {
            time = Time.time;
            counter = 0;
        }

        Debug.Log(counter);
    }
}
