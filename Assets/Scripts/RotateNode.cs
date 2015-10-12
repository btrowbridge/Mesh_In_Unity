using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateNode : MonoBehaviour
{

    public Vector3 startMarker;
    public Vector3 endMarker;
    public float distance = 3.0F;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public float rotate_speed = 25.0f;


    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        startMarker = transform.position;
        endMarker = startMarker;
        endMarker.Set(endMarker.x, endMarker.y - distance, endMarker.z);
        journeyLength = Vector3.Distance(startMarker, endMarker);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        if (distCovered >= distance)
        {
            Vector3 holdMarker = startMarker;
            startMarker = endMarker;
            endMarker = holdMarker;
            startTime = Time.time;
        }
        transform.Rotate(0, Time.deltaTime * rotate_speed, 0);     

    }
}
