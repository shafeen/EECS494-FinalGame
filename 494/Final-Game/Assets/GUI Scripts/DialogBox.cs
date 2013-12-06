//
//	This class will be eventually used 
//	as a general purpose dialog box.
//
//	Still needs some work
//	Currently DialogBox stays open based on a set time.
//
//  Dialog Box will time out after 100 seconds

using UnityEngine;
using System.Collections;

public class DialogBox : MonoBehaviour
{

	//CANCELLABLE is for boxes which can only be closed by B (ie inspect)
	//ACCEPT_DECLINE is for boxes which can use A to accept or B to close (Start level pictures)
	//NEXT is for multi-box messages (if we have any), where there's multiple boxes to show in a row
	//Each one has unique button and key icons displayed
	public enum DialogType {
		CANCELLABLE,
		ACCEPT_DECLINE,
		NEXT };

	public DialogType dialogType;

	//Textures
	public Texture b_button;
	public Texture a_button;
	public Texture left_mouse;
	public Texture right_mouse;

	public string dialogString;
	private string dialogStringToShow;
	private bool openDialogBox;

	// Dialog box parameters
	private float xPosition;
	private float yPosition;	
	private float boxWidth;
	private float boxHeight;
	private float yPadding = 20.0f;
	private float xPadding = 20.0f;
	private GUIStyle fontStyle;

	// Use this for initialization
	void Start () 
	{
		//dialogString = "TIME OUT!! DON'T COME OUT OF YOUR ROOM FOR FIVE MINUTES!!!";
		dialogStringToShow = "";
		openDialogBox = false;

		fontStyle = new GUIStyle(GUI.skin.button);
		fontStyle.fontSize = 40;
	}
	
	// OnGUI is called once per frame
	void OnGUI()
	{

		if (openDialogBox)
		{
			xPosition = Screen.width  * 1/8;
			yPosition = Screen.height * 2/3;
			boxWidth  = Screen.width  * 3/4;
			boxHeight = Screen.height * 1/3 - yPadding;

			Rect dialogRect = new Rect (xPosition, yPosition, boxWidth, boxHeight);

			// Add Style to use --> to skin the dialog box later for polish


			// show one char at a time
			if(dialogStringToShow.Length != dialogString.Length)
				dialogStringToShow += dialogString[dialogStringToShow.Length];


			fontStyle = new GUIStyle(GUI.skin.textField);
			fontStyle.alignment = TextAnchor.MiddleCenter;
			fontStyle.fontSize = 25;

			dialogStringToShow = GUI.TextField(dialogRect, dialogStringToShow, fontStyle);

			//Use for button overlays
			switch (dialogType) {
			case DialogType.CANCELLABLE:
				GUI.DrawTexture(new Rect(xPosition + 4, yPosition + boxHeight - 54, 50, 50), b_button, ScaleMode.ScaleToFit, true, 0);
				break;
				
			case DialogType.ACCEPT_DECLINE:
				GUI.DrawTexture(new Rect(xPosition + 4, yPosition + boxHeight - 54, 50, 50), b_button, ScaleMode.ScaleToFit, true, 0);
				GUI.DrawTexture(new Rect(boxWidth + xPosition - 54, yPosition + boxHeight - 54, 50, 50), a_button, ScaleMode.ScaleToFit, true, 0);

				break;
				
			case DialogType.NEXT:
				GUI.DrawTexture(new Rect(boxWidth + xPosition - 54, yPosition + boxHeight - 54, 50, 50), a_button, ScaleMode.ScaleToFit, true, 0);
				break;
			}
		}
	}





	void OnTriggerEnter(Collider noOneCaresSeriously)
	{
		// disable this if just using the C# property to activate
		//activateDialogBox ();
	}


	void OnTriggerExit(Collider col) {
		disableDialogBox();
	}

	void OnCollisionEnter(Collision col) {
		//activateDialogBox ();
	}

	void activateDialogBox()
	{
		openDialogBox = true;
	}

	void disableDialogBox()
	{
		openDialogBox = false;
	}


	public bool ShowDialog
	{
		get { return openDialogBox;}
		set { 
			if(value) 
				activateDialogBox();
			else
				disableDialogBox();
		}
	}
	                  
}
