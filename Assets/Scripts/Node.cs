/*
------------------------------------------------------------------------------
Notes: Th8ings noted as Mongo Server Approach are to be Changed or deleted since we are moving to the Socket.io approach


------------------------------------------------------------------------------
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using SocketIO;

public class Node : MonoBehaviour
{
    private string nodeName { get { return nodeName; } set { nodeName = value; } }        //for identifying the server
    private Dictionary<string, double> nodeData { get { return nodeData; } set { nodeData = value; } }   //allowing nodes to have sensor data
    //socket Approach
    private SocketIOComponent socket;
    private Dictionary<string, string> query;

    /*Mongo Server Approach
    private sensorData nodeData;
    private MongoDBServer myServer;
    public GameObject thisNodeObject;
    */

    //accessor methods mongo server approach -------------
    /*
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
    */
    //---------------------------------

    //constructor
    public Node (string name)
	{
        //sockert.io approach
		nodeName = name;
        GameObject thisNodeObject = GetComponent<GameObject>(); // May use this instead of assignment
        Instantiate(thisNodeObject);
        
	}

	//setup
	void Start(){
        //socket.io approach
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        query["name"] = nodeName;
        



        /*Mongo Server approach
		//grab server object
		myServer = MongoDBServer.FindObjectOfType <MongoDBServer>();
		//myServer.addToNodeList (this);

		//update the node
		myServer.updateNode (this);
        */

    }
	void FixedUpdate(){
        socket.Emit("query", new JSONObject(query));



        /*Mongo Server Approach
        if(myServer.nodePermissionToSelfUpdate && !myServer.noData)
		    myServer.updateNode(this);
            */
	}
    public void UpdateNode(SocketIOEvent e)
    {
        if (e.name == nodeName)
        {
            parseJson(e);
        }
    }
    public void parseJson(SocketIOEvent e) {
        nodeData["compass"] = e.compass;

        nodeData["magnometer.x"] = e.magnetometer.x;
        nodeData["magnometer.y"] = e.magnetometer.y;
        nodeData["magnometer.z"] = e.magnetometer.z;

        nodeData["barometer.pressure"] = e.barometer.pressure;
        nodeData["barometer.temperature"] = e.barometer.pressure

        nodeData["GPS.latitude.degrees"] = e.GPS.latitude.degrees;
        nodeData["GPS.latitude.minutes"] = e.GPS.latitude.minutes;
        nodeData["GPS.latitude.direction"] = e.GPS.latitude.direction;

        nodeData["GPS.longitude.degrees"] = e.GPS.longitude.degrees;
        nodeData["GPS.longitude.minutes"] = e.GPS.longitude.minutes;
        nodeData["GPS.longitude.direction"] = e.GPS.longitude.direction;



    }
    
}

