using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DynamicTyping : MonoBehaviour {
    private TextMesh DisplayText;
    public string write_this;
    public int col = 12;
    public int row = 6; 
    private int current_position;
    private int final_position;
    private int current_col = 0;
    private int current_row = 0;


    //Currently we can show 7 Rows and 13 Columns of information
    //This can and will change, and a more dynamica (clever) way will 
    //need to be established. 

	// Use this for initialization
	void Start () {

        DisplayText = GetComponent<TextMesh>();
        current_position = 0;
        final_position = write_this.Length;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (current_position < final_position)
        {
            if (current_col == col)
            {
                current_col = 0;
                current_row++;
                if (current_row == row)
                {
                    current_row = 0;
                    DisplayText.text = "";
                } else
                {
                    DisplayText.text = DisplayText.text + "\n";
                }
            }
            DisplayText.text = DisplayText.text + write_this[current_position];
            current_position++;
            current_col++;
        }
        

    }
}
