using UnityEngine;
using System.Collections.Generic;
using SocketIO;

public class NodeManager : MonoBehaviour {

    private SocketIOComponent socket; //socket component
    private Dictionary<string, Node> nodeList; //List that holds all the nodes
    
	// Use this for initialization
	void Start () {
        //socket.io approach
        //retrieve socket component
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        nodeList = new Dictionary<string, Node>(); //create a new dictionary

        socket.On("result", NodeListUpdate); //event listener waiting for the results of the node queries
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        //hod sould I find the missing nodes...?
        //I need to query alfred
	}

    //event handler for the incoming data
    public void NodeListUpdate(SocketIOEvent e) {
        string nodeName = e.data["name"].ToString(); //grabs the name of the node that retrieved the data

        //if node exists
        if (nodeList.ContainsKey(nodeName))
        {
            return;//pass
        }
        else { 
            //if not we make a new node and add it to the dictionary
            nodeList[nodeName] = new Node(nodeName);
        }
    }

}
