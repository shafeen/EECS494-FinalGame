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
	private bool openDialogBox;
	private float dialogDisplayTime;
	private const float displayTime = 5.0f;

	// Dialog box parameters
	private float xPosition;
	private float yPosition;	
	private float boxWidth;
	private float boxHeight;

	// Public settable string
	public string publicString;

	// Use this for initialization
	void Start () 
	{
		dialogString = "\n\n\t\tThis is a sample dialog box.";
		openDialogBox = false;
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
			GUIStyle textFieldStyle  = new GUIStyle(GUI.skin.textField);
			textFieldStyle.fontSize  = 30;
			textFieldStyle.alignment = TextAnchor.MiddleCenter;

			dialogString = GUI.TextField(dialogRect, publicString, textFieldStyle);
		}
	}





	void OnTriggerEnter(Collider noOneCaresSeriously)
	{
		showDialogBox ();
	}

	void showDialogBox()
	{
		openDialogBox = true;
		dialogDisplayTime = Time.time + displayTime; //denotes 10 seconds in the future
	}


	                  
}
