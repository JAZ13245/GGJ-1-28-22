using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimePeriod { Past, Future }

public class TimeState : MonoBehaviour
{
    public TimePeriod originTimeState;
    public TimePeriod currentTimeState;

    public GameObject pastVersion;
    public GameObject futureVersion;

    public Vector3 prevLoc;

    public float layerPriority; // set to 1 to 50: bigger number overlaps lower numbers

    // Start is called before the first frame update
    void Start()
    {
        prevLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MaskUpdate();
        TimeUpdate();
        prevLoc = transform.position;
    }

    private void MaskUpdate()
    {
        switch (currentTimeState)
        {
            case TimePeriod.Past:
                GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                transform.position = new Vector3(transform.position.x, transform.position.y, 50 - layerPriority);
                break;
            case TimePeriod.Future:
                GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
                transform.position = new Vector3(transform.position.x, transform.position.y, -layerPriority);
                break;
        }
    }

    // current time rules implemented:
    // past effects future
    // future doesn't effect past
    private void TimeUpdate()
    {

        if (futureVersion != null || pastVersion != null)
        {
            if (originTimeState == TimePeriod.Past)
            {
                // if the past versin has moved
                if (transform.position != prevLoc)
                {
                    Debug.Log("changed");
                    // update the future version to match the new past version position
                    futureVersion.GetComponent<TimeState>().PastUpdated();
                }
            }
            else if (originTimeState == TimePeriod.Future)
            {

            }
        }
    }

    void PastUpdated()
    {
        if (originTimeState == TimePeriod.Past)
        {

        }
        else if (originTimeState == TimePeriod.Future)
        {
            // if the past version is moved, update the future version to have the new position
            transform.position = pastVersion.transform.position;
        }
    }
}
