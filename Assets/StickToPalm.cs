using UnityEngine;
using System.Collections;

public class StickToPalm : MonoBehaviour {

    private GameObject TV;
    private GameObject Player;
    private Transform TVposition0;

	// Use this for initialization
    
	void Start () {
        TV = GameObject.FindWithTag("Screen");
        TVposition0 = TV.transform;
        

    }
	
	// Update is called once per frame
	void Update () {
        TV.transform.position = this.transform.position;
        TV.transform.rotation = this.transform.rotation;
	}

    void OnDestroy() {
        TV.transform.position = TVposition0.position;
        TV.transform.rotation = TVposition0.rotation;
    }
}
