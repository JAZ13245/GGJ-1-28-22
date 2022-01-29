using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftLine : MonoBehaviour
{
    LineRenderer theLine;
     
    // Start is called before the first frame update
    void Start()
    {
        theLine = this.GetComponent<LineRenderer>();
        theLine.material = new Material(Shader.Find("Sprites/Default"));
        theLine.SetColors(Color.cyan, Color.cyan);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = theLine.GetPosition(0);
        Vector3 endPoint= theLine.GetPosition(1);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            theLine.SetPosition(0, new Vector3(startPoint.x, startPoint.y-1, startPoint.z));
            theLine.SetPosition(1, new Vector3(endPoint.x, endPoint.y + 1, endPoint.z));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            theLine.SetPosition(0, new Vector3(startPoint.x, startPoint.y + 1, startPoint.z));
            theLine.SetPosition(1, new Vector3(endPoint.x, endPoint.y - 1, endPoint.z));
        }
    }
}
