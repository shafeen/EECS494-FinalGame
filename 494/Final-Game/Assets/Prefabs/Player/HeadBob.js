#pragma strict

 private var timer = 0.0; 
 public var bobSpeed = 0.18; 
 public var bobAmplitude = 0.2; 
 private var midpoint = 0.0;
 
function Start () {
	midpoint = transform.localPosition.y;
}

 function Update () { 
    var sinTime = 0.0; 
    var horizontal = Mathf.Abs(Input.GetAxis("Horizontal"));
    var vertical = Mathf.Abs(Input.GetAxis("Vertical"));
    if (horizontal == 0 && vertical == 0){timer = 0.0;} 
    else { 
       sinTime = Mathf.Sin(timer); 
       timer += bobSpeed;
       timer = timer % (Mathf.PI * 2); 
    } 
    if (sinTime != 0) { 
       var changeFromMid = sinTime * bobAmplitude; 
       var totalAxes = Mathf.Clamp((horizontal + vertical),0.0,1.0); 
       changeFromMid *= totalAxes; 
       transform.localPosition.y = midpoint + changeFromMid; 
    } 
    else { 
       transform.localPosition.y = midpoint; 
    } 
 }