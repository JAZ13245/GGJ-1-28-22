using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftLine : MonoBehaviour
{
    public GameObject RiftMask;

    LineRenderer theLine;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        theLine = this.GetComponent<LineRenderer>();
        //theLine.material = new Material(Shader.Find("Sprites/Default"));
        theLine.SetColors(Color.cyan, Color.cyan);
        theLine.SetPosition(1, new Vector3(0,0,-9));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle++;
            RiftMask.transform.Rotate(new Vector3(0, 0, 1));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            angle--;
            RiftMask.transform.Rotate(new Vector3(0, 0, -1));
        }

        float newAngle = angle;
        angle *= Mathf.Deg2Rad;
        theLine.SetPosition(0, new Vector3(Mathf.Cos(angle)*6, Mathf.Sin(angle)*6,-9));
        theLine.SetPosition(2, new Vector3(Mathf.Cos(angle+ Mathf.PI)*6, Mathf.Sin(angle+ Mathf.PI)*6,-9));
        angle = newAngle;

        if (angle >= 360 || angle <= -360) { angle = 0; }
    }
}