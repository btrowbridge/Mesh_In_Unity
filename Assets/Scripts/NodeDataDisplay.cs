using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeDataDisplay : MonoBehaviour {
    //public GameObject TextCamera;
    // Use this for initialization
    public bool hasCompass = false;
	public bool hasTherm = false;
    //public bool hasMagnetometer = true;
    //public bool hasBarometer = true;
    //public bool hasGPS = true;
    public int compass = 90;
	public int temp = 100;
    public Material CompassTex;
	public Material ThermTex;
    public GameObject Logo;
	private Material material;

	private Dictionary<string, Material> Logos;

    void Start () {
		Logos = new Dictionary<string,Material > ();
		Logos.Add ("compass", CompassTex);
		Logos.Add ("thermometer", ThermTex);

	}
	
	// Update is called once per frame
	void Update () {; 
	    if (hasCompass == true)
        {
            GetComponentInChildren<DynamicTyping>().write_this = "Compass Heading=" + compass.ToString() + "Degrees";
			Logos.TryGetValue("compass", out material);
			Logo.GetComponent<MeshRenderer>().sharedMaterial = material;
        	//Below line for testing only, remove later
			hasCompass = false;
		}
		if (hasTherm == true) {
			GetComponentInChildren<DynamicTyping>().write_this = "Temp =       " + compass.ToString() + "    Degrees C";
			Logos.TryGetValue("thermometer", out material);
			Logo.GetComponent<MeshRenderer>().sharedMaterial = material;
			//Below line for testing only, remove later
			hasTherm = false;
		}

	}
}
