using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RiftLine : MonoBehaviour
{
    public GameObject RiftMask;
    public LevelGenerator lg;
    public float angle;
    public float targetAngle;
    public int lineStyle;

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
        angle = -21420420;

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
        playerOnePos = lg.playerOne.transform.position;
        playerTwoPos = lg.playerTwo.transform.position;

        if (angle == -21420420)
        {
            if(playerOnePos != Vector3.zero || playerTwoPos != Vector3.zero)
            {
                angle = Mathf.Atan2(playerOnePos.y - playerTwoPos.y, playerOnePos.x - playerTwoPos.x) * Mathf.Rad2Deg + 270;
                SetAngle();

                targetAngle = angle;
            }
            return;
        }
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);

        

        playerOneQuadrant = GetQuadrant(playerOnePos);
        playerTwoQuadrant = GetQuadrant(playerTwoPos);

        // TODO: Implement Quadtree for Quadrants
        if (lineStyle == 1) {
            ShiftAngle(GetLineQuad());
            SetAngle();
        }
        else if (lineStyle == 2) {
            SetAngleAlt((playerOnePos + (playerTwoPos - playerOnePos) / 2));
        }
        else if (lineStyle == 3)
        {
            angle += 5;
            SetAngle();
        }
        else if (lineStyle == 4)
        {
            const float alpha = 0.01f; // for line angle transition
            const float beta = 2; // for line snapping

            var angle2 = Mathf.Atan2(playerOnePos.y - playerTwoPos.y, playerOnePos.x - playerTwoPos.x)*Mathf.Rad2Deg + 270;
            angle2 = Mathf.Round(angle2 / 90 * beta) * 90 / beta;
            while (angle2 < 0) { angle2 += 360; }
            while (angle2 > 360) { angle2 -= 360; }
            
            if(Mathf.Abs(angle2-angle) > Mathf.Abs(angle2+360 - angle))
            {
                angle -= 360;
                //SetAngle();
            }
            else if(Mathf.Abs(angle2-angle) > Mathf.Abs(angle2-360 - angle))
            {
                angle += 360;
                //SetAngle();
            }
            
            angle = angle2 * alpha + (1-alpha)*angle;
            //if (angle > 360) { angle-=360}
            //ShiftAngle(angle2);
            SetAngle();
        }
        else if(lineStyle == 5)
        {
            //const float alpha = 0.004f; 
            const float alpha = 0.064f; // for line angle transition
            const float beta = 2; // for line snapping
            const float close = 1;
            
            var angle2 = Mathf.Atan2(playerOnePos.y - playerTwoPos.y, playerOnePos.x - playerTwoPos.x) * Mathf.Rad2Deg + 270;
            angle2 = Mathf.Round(angle2 / 90 * beta) * 90 / beta;
            while (angle2 < 0) { angle2 += 360; }
            while (angle2 > 360) { angle2 -= 360; }

            if (Mathf.Abs(angle2 - angle) > Mathf.Abs(angle2 + 360 - angle))
            {
                angle -= 360;
                //SetAngle();
            }
            else if (Mathf.Abs(angle2 - angle) > Mathf.Abs(angle2 - 360 - angle))
            {
                angle += 360;
                //SetAngle();
            }
            
            if (Mathf.Sqrt(Mathf.Pow(playerOnePos.y - playerTwoPos.y, 2)
                + Mathf.Pow(playerOnePos.x - playerTwoPos.x, 2)) < close)
            {
                angle2 = targetAngle;
            }
            else
            {
                targetAngle = angle2;
            }
            angle = angle2 * alpha + (1 - alpha) * angle;
            //if (angle > 360) { angle-=360}
            //ShiftAngle(angle2);
            SetAngle();
        }
        else
        {
            SetAngle();
        }

        //while (angle < 0){ angle += 360; }
        //while (angle > 360){ angle -= 360; }

        //if (angle >= 360 || angle <= -360) { angle = 0; }
    }


    // returns the angle the rift line should be based on the quadrants of the two players
    private int GetLineQuad()
    {
        if (playerOneQuadrant == 1) {
            if (playerTwoQuadrant == 2) { return 270; }
            if (playerTwoQuadrant == 3) { return 315; }
            if (playerTwoQuadrant == 4) { return 0; }
        }
        else if (playerOneQuadrant == 2) {
            if (playerTwoQuadrant == 1) { return 90; }
            if (playerTwoQuadrant == 3) { return 0; }
            if (playerTwoQuadrant == 4) { return 45; }
        }
        else if (playerOneQuadrant == 3) {
            if (playerTwoQuadrant == 1) { return 135; }
            if (playerTwoQuadrant == 2) { return 180; }
            if (playerTwoQuadrant == 4) { return 90; }
        }
        else if (playerOneQuadrant == 4) {
            if (playerTwoQuadrant == 1) { return 180; }
            if (playerTwoQuadrant == 2) { return 225; }
            if (playerTwoQuadrant == 3) { return 270; }
        }
        return -1;
    }


    // Adds feathering to the angle changing
    // Instead of instantly going to the angle desired, transition to it overtime
    private void ShiftAngle(float desiredAngle) {
        if (desiredAngle != angle) {
            if(desiredAngle == 0) {
                if(angle > 180) { angle += 5; }
                if(angle < 180) { angle -= 5; }
            }
            else if(angle == 0) {
                if(desiredAngle > 180) { angle -= 5; }
                if(desiredAngle < 180) { angle += 5; }
            }
            else if (desiredAngle > angle) { angle += 5; }
            else if (desiredAngle < angle) { angle -= 5; }
        }
    }


    // set the rift line and mask to the current angle
    private void SetAngle() {
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

    private void SetAngleAlt(Vector3 lookinAt)
    {
        RiftMask.transform.rotation = Quaternion.LookRotation(lookinAt, lookinAt);
        lineCollision.transform.rotation = Quaternion.LookRotation(lookinAt, lookinAt);
        lineParticles.transform.rotation = Quaternion.LookRotation(lookinAt, lookinAt);
    }

    // takes in a player's vector3 and returns what qudrant they're in
    private int GetQuadrant(Vector3 obj) {
        if (obj.x > 0 && obj.y > 0) { return 1; }
        else if (obj.x < 0 && obj.y > 0) { return 2; }
        else if (obj.x < 0 && obj.y < 0) { return 3; }
        else if (obj.x > 0 && obj.y < 0) { return 4; }
        else return 0;
    }
}