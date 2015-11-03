using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ParticleSystem))]
public class ParticleBehavior : MonoBehaviour {

    private Rigidbody rigidbody;
    private ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;
    private Transform orbital;           //this objects transform
    private Transform nodeTarget;        // transform of target node to rotate around
    private GameObject[] nodes;           //list of nodes in scene
       
    public GameObject nodeObject;        // refers to the target to be emmitted toward
    public float speed;                  //speed of orbit
    public float radius = 4;             //radius of orbit

    //for easier editing of all emmitters
    public float startSpeed=1;           //speed of particles
    public int numParticles = 40;        //num of particles at one time
    
	// Use this for initialization
    //John is the illest - Brad
	void Start () {
        //edits the particle system
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.startSpeed = startSpeed;
        particleSystem.emissionRate = numParticles;

        //reference to target node for orbiting
        nodeTarget = nodeObject.transform;


        //places emmitter at radius
        transform.position = (transform.position - nodeTarget.position).normalized * radius + nodeTarget.position;
    }
    void Awake() {
        //reference to rigidbody and transform for force appplication
        rigidbody = GetComponent<Rigidbody>();
        orbital = this.transform;

        //starting force
        rigidbody.AddForce(Vector3.left * speed);
        rigidbody.AddForce(Vector3.up * speed);
        
        
    }
    void Update() {
        nodes = GameObject.FindGameObjectsWithTag("node");
     
        // random node from list
        nodeObject = nodes[Random.Range(0,nodes.Length)];

        //calculate distance from eimission
        float distance = Vector3.Distance(gameObject.transform.position, nodeObject.transform.position);

        //lifetime particle depends on object they are looking at
        particleSystem.startLifetime = distance / particleSystem.startSpeed;

        //makes sure the emmitter faces node
        transform.LookAt(nodeObject.transform);

        //makes sure the emitter stays at the radius
        transform.position = (transform.position - nodeTarget.position).normalized * radius + nodeTarget.position;

        //vector pointing to the node body it is orbiting
        Vector3 line = nodeTarget.position - orbital.position;
        line.Normalize(); // set to 1
      
        
        //centrifical force
        rigidbody.AddForce(line * speed);
    }

	// 
	void FixedUpdate () {


	}

}
