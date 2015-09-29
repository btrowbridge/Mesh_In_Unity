using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

public class MongoDBServer : MonoBehaviour {


	private List<Node>[] nodes;					//list of nodes on server
	private MongoServerSettings settings;		//server settings
	private MongoServer server;					//server
					
	public int delay = 10;						// delay of how old you want your data (seconds)

	// Use this for initialization
	void Start () {

		// Create server settings to pass connection string, timeout, etc.
		settings = new MongoServerSettings();
		settings.Server = new MongoServerAddress("localhost", 27017);

		// Create server object to communicate with our server
		server = new MongoServer(settings);


	}
	/*
	public void addToNodeList(Node node)
	{
	
	}
	*/
	//grab data from specific node
	public void updateNode(Node node)
	{
		//get DB from server
		var _database = server.GetDatabase("sensornetwork");
		//get collection from server
		var collection = _database.GetCollection<BsonDocument> ("sensordata");
		//create a builder to build query
		var builder = Builders<BsonDocument>.Filter;
		//look for Bsondocument with same name as node
		var filter = builder.Eq ("name", (string)node.getName ()) & builder.Eq ("timestamp",(int)(node.getTimeStamp () + delay));
		BsonDocument result = collection.Find (filter).ToBsonDocument ();

		//parse the bson document and update the nnode data members
		node.pointToSensor ().parseBsonToSensorData (result);

	}


	// Update is called once per frame
	void FixedUpdate () 
	{

	}

}
