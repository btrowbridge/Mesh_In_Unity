/*
------------------------------------------------------------------------------
Notes: Th8ings noted as Mongo Server Approach are to be Changed or deleted since we are moving to the Socket.io approach


------------------------------------------------------------------------------
*/

using UnityEngine;
using System.Collections.Generic;
using SocketIO;

public class Node : MonoBehaviour
{
    private string nodeName { get { return nodeName; } set { nodeName = value; } }        //for identifying the server
    private Dictionary<string, string> nodeData { get { return nodeData; } set { nodeData = value; } }   //allowing nodes to have sensor data
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
        //retrieve socket component
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        socket.On("result", UpdateNode);  //event listener for query results

        //create dictionary for nodeData
        nodeData = new Dictionary<string, string>();

        //create query based on the node's name
        query = new Dictionary<string, string>();
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
        //on each fixed update emit the query for the latest node data
        socket.Emit("query", new JSONObject(query));



        /*Mongo Server Approach
        if(myServer.nodePermissionToSelfUpdate && !myServer.noData)
		    myServer.updateNode(this);
        */
	}

    //event handler for the json object
    public void UpdateNode(SocketIOEvent e)
    {   
        //if the result is correct
        if (e.data["name"].ToString() == nodeName)
        {
            //parse the data
            parseJson(e);
        }
    }
    public void parseJson(SocketIOEvent e) {

        nodeData = e.data.ToDictionary(); //apparently parsing is easy.....

        /*
        extraneas structure for node data dictionary
        nodeData["compass"] = e.data["nodeData.compass"].ToString();

        nodeData["magnometer.x"] = e.data["magnetometer.x"].ToString();
        nodeData["magnometer.y"] = e.data["magnetometer.y"].ToString();
        nodeData["magnometer.z"] = e.data["magnetometer.z"].ToString();

        nodeData["barometer.pressure"] = e.data["barometer.pressure"].ToString();
        nodeData["barometer.temperature"] = e.data["barometer.pressure"].ToString();

        nodeData["GPS.latitude.degrees"] = e.data["GPS.latitude.degrees"].ToString();
        nodeData["GPS.latitude.minutes"] = e.data["GPS.latitude.minutes"].ToString();
        nodeData["GPS.latitude.direction"] = e.data["GPS.latitude.direction"].ToString();

        nodeData["GPS.longitude.degrees"] = e.data["GPS.longitude.degrees"].ToString();
        nodeData["GPS.longitude.minutes"] = e.data["GPS.longitude.minutes"].ToString();
        nodeData["GPS.longitude.direction"] = e.data["GPS.longitude.direction"].ToString();
        */


    }
    
}

