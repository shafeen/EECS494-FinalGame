//
//	This class will be eventually used 
//	as a general purpose dialog box.
//
//	Still needs some work
//	Currently DialogBox stays open based on a set time.
//

using UnityEngine;
using System.Collections;

public class DialogBox : MonoBehaviour
{

	private string dialogString;
	private string dialogStringToShow;
	private bool openDialogBox;
	private float dialogDisplayTime;

	// Dialog box parameters
	private float xPosition;
	private float yPosition;	
	private float boxWidth;
	private float boxHeight;
	private GUIStyle fontStyle;

	// Use this for initialization
	void Start () 
	{
		dialogString = "TIME OUT!! DON'T COME OUT OF YOUR ROOM FOR FIVE MINUTES!!!";
		dialogStringToShow = "";
		openDialogBox = false;

		fontStyle = new GUIStyle(GUI.skin.button);
		fontStyle.fontSize = 40;
	}
	
	// OnGUI is called once per frame
	void OnGUI()
	{

		if (openDialogBox && Time.time < dialogDisplayTime)
		{
			xPosition = Screen.width  * 1/8;
			yPosition = Screen.height * 2/3;
			boxWidth  = Screen.width  * 3/4;
			boxHeight = Screen.height * 1/3;

			Rect dialogRect = new Rect (xPosition, yPosition, boxWidth, boxHeight);

			// Add Style to use --> to skin the dialog box later for polish



			// show one char at a time
			if(dialogStringToShow.Length != dialogString.Length)
				dialogStringToShow += dialogString[dialogStringToShow.Length];


			fontStyle = new GUIStyle(GUI.skin.textField);
			fontStyle.alignment = TextAnchor.MiddleCenter;
			fontStyle.fontSize = 25;

			dialogStringToShow = GUI.TextField(dialogRect, dialogStringToShow, fontStyle);
		}
	}





	void OnTriggerEnter(Collider noOneCaresSeriously)
	{
		openDialogBox = true;
		dialogDisplayTime = Time.time + 10.0f; //denotes 10 seconds in the future
	}


	                  
}
