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
        TV.transform.rotation.SetEulerAngles(0, 90, 0);
	}
	
	// Update is called once per frame
	void Update () {
        TV.transform.position = this.transform.position;
        TV.transform.rotation.y = this.transform.rotation.y + 90.0f;
	}

    void OnDestroy() {
        TV.transform.position = TVposition0.position;
        TV.transform.rotation = TVposition0.rotation;
    }
}
