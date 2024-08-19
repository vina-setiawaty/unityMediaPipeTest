using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseCircling : MonoBehaviour
{
    private bool changePosX;
    private bool changePosY;
    private bool changeNegX;
    private bool changeNegY;
    private int counter;
    public int threshold = 8;
    public float rad = 100f;
    public float timeLimit = 2;
    private float changeDirX;
    private float changeDirY;
    private float oldX;
    private float oldY;
    private Vector2 pos;
    private float time; 

    public UnityEvent triggerEvent;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(Input.mousePosition.x, Input.mousePosition.x);
        changeDirX = 0;
        changeDirY = 0;
        oldX = pos.x;
        oldY = pos.y;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (changeDirX == 0)
        {
            changeDirX = Mathf.Sign(newPos.x - pos.x);
            oldX = newPos.x;
        } else
        {
            if (Mathf.Sign(newPos.x - pos.x) != changeDirX && Mathf.Abs(newPos.x - oldX) > rad)
            {
                if (Mathf.Sign(newPos.x - pos.x) < 0)
                {
                    changeNegX = true;
                    changeDirX = Mathf.Sign(newPos.x - pos.x);
                } else if (Mathf.Sign(newPos.x - pos.x) > 0)
                {
                    changePosX = true;
                    changeDirX = Mathf.Sign(newPos.x - pos.x);
                }
                oldX = newPos.x;
            }
        }
        if (changeDirY == 0)
        {
            changeDirY = Mathf.Sign(newPos.y - pos.y);
            oldY = newPos.y;
        } else
        {
            if (Mathf.Sign(newPos.y - pos.y) != changeDirY && Mathf.Abs(newPos.y - oldY) > rad)
            {
                if (Mathf.Sign(newPos.y - pos.y) < 0)
                {
                    changeNegY = true;
                    changeDirY = Mathf.Sign(newPos.y - pos.y);
                }
                else if (Mathf.Sign(newPos.y - pos.y) > 0)
                {
                    changePosY = true;
                    changeDirY = Mathf.Sign(newPos.y - pos.y);
                }
                oldY = newPos.y;
            }
        }

        if (changePosX && changePosY && changeNegY && changeNegX)
        {
            counter++;
            changePosX = false;
            changePosY = false;
            changeNegX = false;
            changeNegY = false;
        }

        if (counter > threshold)
        {
            counter = 0;
            triggerEvent.Invoke();
        }

        if (Time.time - time > timeLimit)
        {
            time = Time.time;
            counter = 0;
        }

        pos = newPos;
    }
}
