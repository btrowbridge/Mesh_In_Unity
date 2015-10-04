/*
------------------------------------------------------------------------------



------------------------------------------------------------------------------
*/
/*
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
    public GameObject thisNode;
   

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
	public sensorData pointToSensor(){
		return nodeSensor;
	}
	//---------------------------------

	//constructor
	public Node (string name)
	{
		nodeName = name;
        Instantiate(thisNode);
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
*/
