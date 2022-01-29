using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftLine : MonoBehaviour
{
    LineRenderer theLine;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        theLine = this.GetComponent<LineRenderer>();
        theLine.material = new Material(Shader.Find("Sprites/Default"));
        theLine.SetColors(Color.cyan, Color.cyan);
        theLine.SetPosition(1, new Vector3(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle++;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle--;
        }
        angle *= Mathf.Deg2Rad;
        theLine.SetPosition(0, new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0) * 6);
        theLine.SetPosition(2, new Vector3(Mathf.Cos(angle+ Mathf.PI), Mathf.Sin(angle+ Mathf.PI),0)*6);
        angle *= Mathf.Rad2Deg;
        if (angle >= 360) { angle = 0; }
    }
}