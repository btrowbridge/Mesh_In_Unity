using UnityEngine;
using System.Collections;

public class NodeDataDisplay : MonoBehaviour {
    //public GameObject TextCamera;
    // Use this for initialization
    public bool hasCompass = true;
    //public bool hasMagnetometer = true;
    //public bool hasBarometer = true;
    //public bool hasGPS = true;
    public int compass = 90;
    public Material CompassTex;
    public GameObject Logo;

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (hasCompass == true)
        {
            GetComponentInChildren<DynamicTyping>().write_this = "Compass Heading=" + compass.ToString() + "Degrees";
            Logo.GetComponent<MeshRenderer>().sharedMaterial = CompassTex;
            hasCompass = false;
        }
	}
}
