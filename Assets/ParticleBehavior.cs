using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ParticleSystem))]
public class ParticleBehavior : MonoBehaviour {

    private Rigidbody rigidbody;
    private ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;
    private Transform orbital;
    private Transform nodeTarget;
    public GameObject nodeObject;
    public float speed;
    
	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();
        
        
        nodeTarget = nodeObject.transform;
	}
    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        orbital = this.transform;
        rigidbody.AddForce(transform.forward * speed);
        rigidbody.AddForce(transform.up * speed);
    }
	// Update is called once per frame
	void Update () {

        transform.LookAt(nodeTarget);
        
        Vector3 line = nodeTarget.position - orbital.position;
        line.Normalize();
        
        float distance = Vector3.Distance(gameObject.transform.position, nodeObject.transform.position);
    
        rigidbody.AddForce(line * 10 / distance);

        particleSystem.startLifetime = distance / particleSystem.startSpeed;

	}

}
