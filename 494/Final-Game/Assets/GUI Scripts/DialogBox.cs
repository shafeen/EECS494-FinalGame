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

	// Dialog box parameters
	private float xPosition;
	private float yPosition;	
	private float boxWidth;
	private float boxHeight;

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
			// Add Style to use --> to skin the dialog box later for polish

			dialogString = GUI.TextField(dialogRect, dialogString);
		}
	}





	void OnTriggerEnter(Collider noOneCaresSeriously)
	{
		openDialogBox = true;
		dialogDisplayTime = Time.time + 10.0f; //denotes 10 seconds in the future
	}


	                  
}
