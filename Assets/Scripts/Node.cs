/*
------------------------------------------------------------------------------



------------------------------------------------------------------------------
*/

using UnityEngine;
using System.Collections;
using MongoDB.Bson;
public class Node : MonoBehaviour
{
	private string nodeName{ get; set; }        //for identifying the server
    [SerializeField]
    private sensorData nodeSensor;	//allowing nodes to have sensor data
	private int timeStamp{ get; set; }
    private MongoDBServer myServer;
    public GameObject thisNodeObject;
   

	//accessor methods -------------
	public string getName(){
		return nodeName;
	}
	public int getTimeStamp(){
		return timeStamp;
	}
	public void setTimeStamp(int time){
		timeStamp = time;
	}
    //points to the node sensor data
	public sensorData pointToSensor(){
		return nodeSensor;
	}
	//---------------------------------

	//constructor
	public Node (string name)
	{
		nodeName = name;
        GameObject thisNodeObject = GetComponentInParent<GameObject>(); // May use this instead of assignment
        Instantiate(thisNodeObject);
	}

	//setup
	void Awake(){
		//grab server object
		myServer = MongoDBServer.FindObjectOfType <MongoDBServer>();
		//myServer.addToNodeList (this);

		//update the node
		myServer.updateNode (this);

	}
	void FixedUpdate(){
        if(myServer.nodePermissionToSelfUpdate)
		    myServer.updateNode(this);
	}



}

