using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RiftLine : MonoBehaviour
{
    public GameObject RiftMask;
    public GameManager gm;
    public float angle;

    LineRenderer theLine;

    LineRenderer playerLine;

    private bool leftHeld;
    private bool rightHeld;

    Vector3 playerOnePos;
    Vector3 playerTwoPos;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        leftHeld = false;
        rightHeld = false;

        theLine = this.GetComponent<LineRenderer>();
        playerLine = gm.GetComponent<LineRenderer>();

        theLine.SetColors(Color.cyan, Color.cyan);
        theLine.SetPosition(1, new Vector3(0,0,-9));


        playerLine = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);

        playerOnePos = gm.playerOne.transform.position;
        playerTwoPos = gm.playerTwo.transform.position;

        
        gm.GetComponent<LineRenderer>().SetPosition(1, (playerOnePos + (playerTwoPos - playerOnePos) / 2));
        gm.GetComponent<LineRenderer>().SetPosition(0, new Vector3(gm.GetComponent<LineRenderer>().GetPosition(1).x, 0,-9));
        gm.GetComponent<LineRenderer>().SetPosition(2, new Vector3(0,0,-9));

        float l1 = (gm.GetComponent<LineRenderer>().GetPosition(0) - gm.GetComponent<LineRenderer>().GetPosition(1)).magnitude;
        float l2 = (gm.GetComponent<LineRenderer>().GetPosition(1) - gm.GetComponent<LineRenderer>().GetPosition(2)).magnitude;
        angle = Mathf.Asin(l1 / l2) * Mathf.Rad2Deg;
        if (gm.GetComponent<LineRenderer>().GetPosition(0).y < gm.GetComponent<LineRenderer>().GetPosition(1).y)
        {
            angle *= -1;
        }
        if (gm.GetComponent<LineRenderer>().GetPosition(0).x > 0)
        {
            angle += 180;
            angle *= -1;
        }

        //angle = Mathf.Asin(gm.GetComponent<LineRenderer>().GetPosition(0));
        //angle = Vector2.Angle(new Vector3(0, 0),(playerOnePos + (playerTwoPos - playerOnePos) / 2))*Mathf.Deg2Rad;

        //Vector3 pos1 = playerOnePos + (playerTwoPos - playerOnePos);
        //Vector3 pos2 = new Vector3(0, 0, -9);
        //float length = (pos2 - pos1).magnitude;



        //Mathf.Acos(length/0);


        SetAngle();
        GetDistanceApart();

        if (angle >= 360 || angle <= -360) { angle = 0; }
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

    private void GetDistanceApart()
    {
        
        Vector2 pivot = new Vector3(0, 0);
     
        CompareValues(playerOnePos.x,playerTwoPos.x);
        CompareValues(playerOnePos.y,playerTwoPos.y);

        Debug.Log("x:"+CompareValues(playerOnePos.x, playerTwoPos.x));
        Debug.Log("y:" + CompareValues(playerOnePos.y, playerTwoPos.y));



        float CompareValues(float first,float second)
        {
            return Mathf.Abs(first - second);
        }
        float GiveBetweenValue(float first,float second)
        {
            return Mathf.Abs(first - second);
        }
    }
}

