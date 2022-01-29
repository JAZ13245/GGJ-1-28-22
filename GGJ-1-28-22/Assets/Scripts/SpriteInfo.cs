using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public float radius;
    public Vector3 center;
    public Vector3 lowLeft;
    public Vector3 upRight;
    public float xScale;
    public float yScale;

    void Start()
    {
        radius = gameObject.GetComponent<SpriteRenderer>().bounds.extents.magnitude;
        center = gameObject.GetComponent<SpriteRenderer>().bounds.center;

        xScale = gameObject.transform.localScale.x;
        yScale = gameObject.transform.localScale.y;

        lowLeft = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.min * xScale;
        upRight = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.max * yScale;
    }
}
