using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RiftLine : MonoBehaviour
{
    public GameObject RiftMask;
    public GameManager gm;
    public float angle;
    public int quadrant;

    LineRenderer theLine;

    private bool leftHeld;
    private bool rightHeld;

    Vector3 playerOnePos;
    Vector3 playerTwoPos;

    // Start is called before the first frame update
    void Start()
    {
        quadrant = 0;
        angle = 0;
        leftHeld = false;
        rightHeld = false;

        theLine = this.GetComponent<LineRenderer>();

        theLine.SetColors(Color.red, Color.cyan);
        //theLine.colorGradient = Gradient.
        theLine.SetPosition(1, new Vector3(0,0,-9));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);

        playerOnePos = gm.playerOne.transform.position;
        playerTwoPos = gm.playerTwo.transform.position;

        Move();
        SetAngle();

        if (angle >= 360 || angle <= -360) { angle = 0; }
    }

    public void LeftHeld(InputAction.CallbackContext context)
    {
        if (context.started) { leftHeld = true; }
        if (context.canceled) { leftHeld = false; }
    }

    public void RightHeld(InputAction.CallbackContext context)
    {
        if (context.started) { rightHeld = true; }
        if (context.canceled) { rightHeld = false; }
    }

    private void Move()
    {
        if (rightHeld) { angle--; }
        if (leftHeld) { angle++; }
    }

    private void SetAngle()
    {
        RiftMask.transform.rotation = Quaternion.identity;
        RiftMask.transform.Rotate(new Vector3(0, 0, angle));

        float newAngle = angle;
        angle *= Mathf.Deg2Rad;
        theLine.SetPosition(0, new Vector3(Mathf.Cos(angle) * 6, Mathf.Sin(angle) * 6, -9));
        theLine.SetPosition(2, new Vector3(Mathf.Cos(angle + Mathf.PI) * 6, Mathf.Sin(angle + Mathf.PI) * 6, -9));
        angle = newAngle;
    }
}


/*
        gm.GetComponent<LineRenderer>().SetPosition(1, (playerOnePos + (playerTwoPos - playerOnePos) / 2));
        /*
        gm.GetComponent<LineRenderer>().SetPosition(1, new Vector3(Mathf.Abs(gm.GetComponent<LineRenderer>().GetPosition(1).x),
             Mathf.Abs(gm.GetComponent<LineRenderer>().GetPosition(1).y),-9));
        
        gm.GetComponent<LineRenderer>().SetPosition(0, new Vector3(gm.GetComponent<LineRenderer>().GetPosition(1).x, 0, -9));
        gm.GetComponent<LineRenderer>().SetPosition(2, new Vector3(0, 0, -9));
        gm.GetComponent<LineRenderer>().SetPosition(3, (playerOnePos + (playerTwoPos - playerOnePos) / 2));
        gm.GetComponent<LineRenderer>().SetPosition(4, new Vector3(0, gm.GetComponent<LineRenderer>().GetPosition(1).y, -9));


        Vector3 v0 = gm.GetComponent<LineRenderer>().GetPosition(0);
        Vector3 v1 = gm.GetComponent<LineRenderer>().GetPosition(1);
        Vector3 v2 = gm.GetComponent<LineRenderer>().GetPosition(2);
        Vector3 v3 = gm.GetComponent<LineRenderer>().GetPosition(3);
        Vector3 v4 = gm.GetComponent<LineRenderer>().GetPosition(4);


        float l1 = (v0 - v1).magnitude;
        float l2 = (v1 - v2).magnitude;
        float l3 = (v2 - v3).magnitude;
        float l4 = (v3 - v4).magnitude;
        
        if(v1.x > 0 && v1.y > 0) { quadrant = 1; }
        if(v1.x < 0 && v1.y > 0) { quadrant = 2; }
        if(v1.x < 0 && v1.y < 0) { quadrant = 3; }
        if(v1.x > 0 && v1.y < 0) { quadrant = 4; }
        
        int rightPlayer;
        int topPlayer;


        if (playerTwoPos.y > playerOnePos.y)
        {
            topPlayer = 2;
        }
        else
        {
            topPlayer = 1;
        }
        if (playerTwoPos.x > playerOnePos.x)
        {
            rightPlayer = 2;
        }
        else
        {
            rightPlayer = 1;
        }

        //if (quadrant == 1 && topPlayer == 2) { quadrant = 3; }
        if (quadrant == 2 && topPlayer == 1) { quadrant = 4; }
        else if (quadrant == 3 && topPlayer == 1) { quadrant = 1; }
        else if (quadrant == 4 && topPlayer == 2) { quadrant = 2; }
        

        if (quadrant == 1)
        {
            angle = Mathf.Asin(l1 / l2) * Mathf.Rad2Deg;
        }
        if (quadrant == 2)
        {
            angle = Mathf.Asin(l4 / l3) * Mathf.Rad2Deg;
            angle += 90;
        }
        else if (quadrant == 3)
        {
            angle = Mathf.Asin(l1 / l2) * Mathf.Rad2Deg;
            angle += 180;
        }
        else if (quadrant == 4)
        {
            angle = Mathf.Asin(l4 / l3) * Mathf.Rad2Deg;
            angle += 270;
        }
        */