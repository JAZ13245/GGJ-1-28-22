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

    private bool leftHeld;
    private bool rightHeld;


    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        leftHeld = false;
        rightHeld = false;

        theLine = this.GetComponent<LineRenderer>();

        theLine.SetColors(Color.cyan, Color.cyan);
        theLine.SetPosition(1, new Vector3(0,0,-9));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);

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
        Vector3 playerOnePos = gm.playerOne.transform.position;
        Vector3 playerTwoPos = gm.playerTwo.transform.position;
        Vector3 pivot = new Vector3(0, 0, -9);
     
        CompareValues(playerOnePos.x,playerTwoPos.x);
        CompareValues(playerOnePos.y,playerTwoPos.y);

        //Debug.Log("1:"+Vector2.Angle(playerOnePos, playerTwoPos));
        //Debug.Log("p1:"+Vector2.Angle(playerOnePos, pivot));
        //Debug.Log("p2:"+Vector2.Angle(playerTwoPos, pivot));
        //Debug.Log("3:" + Mathf.Abs(Vector2.Angle(pivot, playerOnePos) - Vector2.Angle(pivot, playerTwoPos)));
        /*
        Debug.Log("4:" +  Vector2.Angle(Vector2.Angle(playerOnePos, playerTwoPos),pivot));
        Vector3.Cross()
        */
        float CompareValues(float first,float second)
        {
            return Mathf.Abs(first - second);
        }
    }
}

