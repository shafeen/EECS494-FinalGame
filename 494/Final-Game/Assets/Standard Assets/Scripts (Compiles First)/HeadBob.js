#pragma strict

 private var timer = 0.0; 
 public var bobSpeed = 0.18; 
 public var bobAmplitude = 0.2; 
 private var midpoint = 0.0;
 private var prevPosition : Vector3;
function Start () {
	midpoint = transform.localPosition.y;
  prevPosition = transform.position;
}
  function FixedUpdate () {
    var vel = ((transform.position - prevPosition)/Time.deltaTime);
    if(vel.magnitude < 1) {timer = 0.0;}
    prevPosition = transform.position;
  }
 function Update () { 
    var sinTime = 0.0; 
    var horizontal = Mathf.Abs(Mathf.Clamp(Input.GetAxis("L_XAxis_1") + Input.GetAxis("Horizontal"), -1, 1));
    var vertical = Mathf.Abs(Mathf.Clamp(Input.GetAxis("L_YAxis_1") + Input.GetAxis("Vertical"), -1,1));
    if ((horizontal == 0 && vertical == 0)){timer = 0.0;} 
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