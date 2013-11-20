#pragma strict

public var fadeOutTexture : Texture2D;
 
var drawDepth = -1000;
public var timeLeft : float;
public var timeLimit : float;
private var alpha :float = 0; 
 
public var fadeSpeed:float;
 
 
function OnGUI(){
	alpha = timeLeft/timeLimit;

	GUI.color.a = alpha;
 
	GUI.depth = drawDepth;
 
	GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
}
 
//--------------------------------------------------------------------

