using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RiftLine : MonoBehaviour
{
    public GameObject RiftMask;
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
        if (rightHeld) {angle--;}
        if (leftHeld) {angle++;}
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

