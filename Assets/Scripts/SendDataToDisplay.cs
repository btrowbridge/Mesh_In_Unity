using UnityEngine;
using System.Collections;

public class SendDataToDisplay : MonoBehaviour {

	public  GameObject TextCamera;
	private GameObject Screen;
	private GameObject TextData;
	private GameObject Logo;

	// Use this for initialization
	void Start () {
		Screen = TextCamera.transform.FindChild ("Screen");
		TextData = Screen.transform.FindChild ("TextData");
		Logo = Screen.transform.FindChild ("Logo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//On Each Click, send data
	void OnMouseDown(){

	}
}
