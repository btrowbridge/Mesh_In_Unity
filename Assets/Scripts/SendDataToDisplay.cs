using UnityEngine;
using System.Collections;

public class SendDataToDisplay : MonoBehaviour {

	public  GameObject TextCamera;

	// Use this for initialization
	void Start () {
		//Find the text Camera, then load the screen object
		//We more or less need to set up a Web Socket to the screen
		//but through Unity not web.
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			//Access Screen Object
		}
	}
	//On Each Click, set the acces point of the display to be this node
	/* Every time increment, the screen will ask this node again to see
	 * if the data has changed. 
	 * 
	 */

}
