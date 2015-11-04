using UnityEngine;
using System.Collections.Generic;

public class EventHorizon : MonoBehaviour {
    //Credit:  syclamoth from http://answers.unity3d.com/questions/241457/3d-planatary-gravity.html
    // Make sure to add the line 'using System.Collections.Generic'
    // on the first line of the file
    public float forceRadius = 20;
    public float gravPower = 9.81f;
    void FixedUpdate()
    {
        // Populate a list of nearby bodies
        List<Rigidbody> bodies = new List<Rigidbody>();
        foreach (Collider col in Physics.OverlapSphere
            (transform.position, forceRadius))
        {
            if (col.attachedRigidbody != null && !bodies.Contains(col.attachedRigidbody))
            {
                bodies.Add(col.attachedRigidbody);
            }
        }
        // Now you have your rigidbodies, time to add the force!
        foreach (Rigidbody body in bodies)
        {
            float bodyDist = (body.position - transform.position).sqrMagnitude;
            float gravStrengthFactor = Mathf.Pow(forceRadius,2) / bodyDist;
            body.AddForce(-gravStrengthFactor * gravPower *
               (transform.position - body.position) * Time.deltaTime, ForceMode.Acceleration);
        }
    }
}
