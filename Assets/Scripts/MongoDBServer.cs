/*
------------------------------------------------------------------------------
This class represents the access to the MongoDB server and query data from it
Be sure to inclode the CSharp driver located in the assets in your assembly

------------------------------------------------------------------------------
*/

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Diagnostics;



public class MongoDBServer : MonoBehaviour {


	private ArrayList nodes;								//list of nodes on server
	protected static MongoServerSettings settings;			//for settings of server mode
	protected static MongoServer server;					//server
	protected static MongoClient _client;					// for use of client mode
	protected static MongoClientSettings clientSettings; 	// for client settings in client mode
	protected static MongoDatabase _database;				// database

    public bool nodePermissionToSelfUpdate;
	public bool isClient = false;
	public int delay = 10;						// delay of how old you want your data (seconds?)
	public string host = "localhost";			// string to pass for the server host
	public string localhost = "localhost";		// string to pass for a local host
	public int port = 27017;					// port # of server
    public bool noData = true;


	// Use this for initialization
	void Start () {
		nodes = new ArrayList();	//create new list of nodes
        if (!noData)
        {
            if (isClient)
            {

                // Create client settings to pass connection string, timeout, etc.
                clientSettings = new MongoClientSettings();
                clientSettings.Server = new MongoServerAddress(localhost, port);

                //create client part
                _client = new MongoClient(clientSettings);

                //Create server object to communicate with server
                //server = new MongoServer(clientSettings);


            }

            else
            {
                // Create server settings to pass connection string, timeout, etc.
                settings = new MongoServerSettings();
                settings.Server = new MongoServerAddress(host, port);

                // Create server object to communicate with our server
                server = new MongoServer(settings);


            }
            //grab desired database from server
            _database = server.GetDatabase("sensornetwork");
        }

	}

	//adds nod to a list of nodes
	public void addNodeToList(Node node)
	{
		nodes.Add (node);
	}
	
	//update data from existing/specific node
	public void updateNode(Node node)
	{


		//get collection from server
		var collection = _database.GetCollection<BsonDocument> ("sensordata");

		//for delayed timestamp
		int timeStamp =  (int)Stopwatch.GetTimestamp();
		string delayedTime = (timeStamp - delay).ToString (); 

		//Query specific node name at a delayed time
		var query = Query.And (
			Query.EQ("name", node.getName ()),
			Query.EQ("timestamp", delayedTime)
		);

		// turn the result into a list of Bsondocument objects for this program we will only use the first one: (result[0])
		var result = collection.Find (query).ToList<BsonDocument>();


		//parse the first bson document and update the node data members
		node.pointToSensor ().parseBsonToSensorData (result[0]);

	}

	//method that updates a node after the data has already been queried
	void updateNodeByResult(Node node, BsonDocument result){
		node.pointToSensor ().parseBsonToSensorData (result);
	}

	// Fixed Update is called once per per specific amount of time, this is handled in Edit > project settings> time
	void FixedUpdate () 
	{
        if(!nodePermissionToSelfUpdate && !noData)
		    updateNodesFromServer (); // our main looping method
	}


	//method handling
	void updateNodesFromServer(){

		//get DB from server
		var _database = server.GetDatabase ("sensornetwork");
		//get collection from server
		var collection = _database.GetCollection<BsonDocument> ("sensordata");

		//look for Bsondocument with old timestamp
		int timeStamp = (int)Stopwatch.GetTimestamp ();
		string delayedTime = (timeStamp - delay).ToString ();

		//query for a specific delayed time
		var query = Query.EQ ("timestamp", delayedTime);

		//convert results to a list of bson objects
		var result = collection.Find (query).ToList<BsonDocument> ();

        bool isNewNode;									//token to see if the data is a new node
		//process each piece of data collected
		foreach (BsonDocument data in result) {

			isNewNode = true; //token to see if the data is a new node
			foreach (Node node in nodes) {

				//if the name field matches a node on the list
				if (node.getName () == data["name"]) {
					isNewNode = false; //it is not a new node
					updateNodeByResult (node,data); ///update this node
					break; //stop checking node on list
				}
				isNewNode = true; //otherwise it is a new node

			}
			//if it is new..
			if (isNewNode) {
				//add it to the list
				addNodeToList (new Node ((string)data ["name"]));
                
			}
		}

	}
	
}




