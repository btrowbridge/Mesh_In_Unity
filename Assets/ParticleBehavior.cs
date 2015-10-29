using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleBehavior : MonoBehaviour {

    public ParticleSystem particleSystem;
    public ParticleSystem.Particle[] particles;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();
       
	}
	
	// Update is called once per frame
	void Update () {
        int numParticles = particleSystem.GetParticles(particles);
        for (int i = 0; i < numParticles; i++) {
            Vector3 line = gameObject.transform.position - particles[i].position;
            line.Normalize();

            float distance = Vector3.Distance(gameObject.transform.position, particles[i].position);
            particles[i].rigidbody.AddForce(line * 10 / distance);
        }
	}
}
