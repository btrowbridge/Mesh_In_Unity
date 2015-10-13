using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeDataDisplay : MonoBehaviour {
    //public GameObject TextCamera;
    //Use this for initialization
    public bool hasCompass = true;
	public bool hasTherm = true;
    //public bool hasMagnetometer = true;
    //public bool hasBarometer = true;
    //public bool hasGPS = true;

    //Temporary Values for creating debugging
    //Should be removed and made into a separate Test
    //Data set ASAP.
    public double compass;
	public double temp;

    //Materials for Dictionary
    //Need to manually get Files 
    //From Inspector 
    public Material CompassTex;
	public Material ThermTex;

    //Material Dictionary
    public Dictionary<string, Material> Logos;


    public GameObject LogoBox;
	public Material material;
    private Node node;
	public GameObject CurrentNodeObject;

    // cycle will count upwards until reaching the last
    // sensor and then reset to 0. 
    private int cycle;

    private SmartTextMesh smartTextMesh;

    void Start () {

        smartTextMesh = GetComponentInChildren<SmartTextMesh>();

        //node = FindObjectOfType<Node>();
        //compass = node.pointToSensor().compSensor.orientation;

        //Build Dictionary of Textures
        Logos = new Dictionary<string, Material>();
        Logos.Add ("compass", CompassTex);
		Logos.Add ("thermometer", ThermTex);
        cycle = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {;
        if (CurrentNodeObject)
        {
            if (hasCompass == true)
            {
                smartTextMesh.UnwrappedText = "Compass Heading=\n" + compass.ToString() + "\nDegrees";
                smartTextMesh.NeedsLayout = true;
                Logos.TryGetValue("compass", out material);
                LogoBox.GetComponent<MeshRenderer>().material = material;
            }

            if (hasTherm == true)
            {
                smartTextMesh.UnwrappedText = "Temp =\n" + temp.ToString() + "\nDegrees C";
                smartTextMesh.NeedsLayout = true;
                Logos.TryGetValue("thermometer", out material);
                LogoBox.GetComponent<MeshRenderer>().material = material;
            }
        }

	}

	public void setGameObject(string newNodeName){
		CurrentNodeObject = GameObject.Find(newNodeName);

        //DummyData 
        compass = CurrentNodeObject.GetComponent<DummyData>().compass;
        temp = CurrentNodeObject.GetComponent<DummyData>().temperature;
	}
}
