using UnityEngine;
using System.Collections;

public class SendDataToDisplay : MonoBehaviour {

	private  NodeDataDisplay display;

	// Use this for initialization
	void Start () {
        //Find the text Camera, then load the screen object
        //We more or less need to set up a Web Socket to the screen
        //but through Unity not web.
        display = FindObjectOfType<NodeDataDisplay>();

	}
	
	// Update is called once per frame
	void Update () {

	}
    /* On Each Click, Access the Node name
	 * then send the name to the display class
     * The Display class can use this to find
     * the game object. 
	 */
    void OnMouseDown()
    {
        print("Click");
        string objectID = name;
        display.setGameObject(objectID);
    }

}
