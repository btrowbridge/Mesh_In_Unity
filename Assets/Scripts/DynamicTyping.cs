using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DynamicTyping : MonoBehaviour {
    TextMesh instruction; 

	// Use this for initialization
	void Start () {
        instruction = GetComponent<TextMesh>();
        instruction.text = "Now Watch Me Whip";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
