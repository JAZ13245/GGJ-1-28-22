using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RiftLine : MonoBehaviour
{
    public GameObject RiftMask;
    public LevelGenerator lg;
    public float angle;
    //public int quadrant;

    public BoxCollider2D lineCollision;
    public GameObject lineParticles;
    Rigidbody2D lineRigidBody;
    LineRenderer theLine;
    
    private bool leftHeld;
    private bool rightHeld;

    Vector3 playerOnePos;
    Vector3 playerTwoPos;

    public int playerOneQuadrant;
    public int playerTwoQuadrant;



    // Start is called before the first frame update
    void Start()
    {
        //quadrant = 0;
        angle = 270;
        leftHeld = false;
        rightHeld = false;

        theLine = this.GetComponent<LineRenderer>();

        theLine.SetColors(Color.red, Color.cyan);
        theLine.SetPosition(0, new Vector3(-6, 0, -9));

        theLine.SetPosition(1, new Vector3(0,0,-9));
        theLine.SetPosition(2, new Vector3(6, 0, -9));

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);

        playerOnePos = lg.playerOne.transform.position;
        playerTwoPos = lg.playerTwo.transform.position;

        playerOneQuadrant = GetQuadrant(playerOnePos);
        playerTwoQuadrant = GetQuadrant(playerTwoPos);


        ShiftAngle(GetLineQuad());
        SetAngle();

        //if (angle >= 360 || angle <= -360) { angle = 0; }
    }

    private int GetLineQuad()
    {
        if (playerOneQuadrant == 1)
        {
            if (playerTwoQuadrant == 2)
            {
                return 270;
            }
            if (playerTwoQuadrant == 3)
            {
                return 315;
            }
            if (playerTwoQuadrant == 4)
            {
                return 0;
            }
        }
        else if (playerOneQuadrant == 2)
        {
            if (playerTwoQuadrant == 1)
            {
                return 90;
            }
            if (playerTwoQuadrant == 3)
            {
                return 0;
            }
            if (playerTwoQuadrant == 4)
            {
                return 45;
            }
        }
        else if (playerOneQuadrant == 3)
        {
            if (playerTwoQuadrant == 1)
            {
                return 135;
            }
            if (playerTwoQuadrant == 2)
            {
                return 180;
            }
            if (playerTwoQuadrant == 4)
            {
                return 90;
            }
        }
        else if (playerOneQuadrant == 4)
        {
            if (playerTwoQuadrant == 1)
            {
                return 180;
            }
            if (playerTwoQuadrant == 2)
            {
                return 225;
            }
            if (playerTwoQuadrant == 3)
            {
                return 270;
            }
        }
        return -1;
    }

    private void ShiftAngle(int desiredAngle)
    {
        if (desiredAngle != angle)
        {
            if (desiredAngle > angle)
            {
                angle += 5;
            }
            else if (desiredAngle < angle)
            {
                angle -= 5;
            }
        }
    }
        
    


    private void SetAngle()
    {
        RiftMask.transform.rotation = Quaternion.identity;
        RiftMask.transform.Rotate(new Vector3(0, 0, angle));

        lineCollision.transform.rotation = Quaternion.identity;
        lineCollision.transform.Rotate(new Vector3(0, 0, angle));

        lineParticles.transform.rotation = Quaternion.identity;
        lineParticles.transform.Rotate(new Vector3(0, 0, angle));

        float newAngle = angle;
        angle *= Mathf.Deg2Rad;
        theLine.SetPosition(0, new Vector3(Mathf.Cos(angle) * 6, Mathf.Sin(angle) * 6, -9));
        theLine.SetPosition(2, new Vector3(Mathf.Cos(angle + Mathf.PI) * 6, Mathf.Sin(angle + Mathf.PI) * 6, -9));
        angle = newAngle;
    }

    private int GetQuadrant(Vector3 obj)
    {
        if (obj.x > 0 && obj.y > 0) { return 1; }
        else if (obj.x < 0 && obj.y > 0) { return 2; }
        else if (obj.x < 0 && obj.y < 0) { return 3; }
        else if (obj.x > 0 && obj.y < 0) { return 4; }
        else return 0;
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