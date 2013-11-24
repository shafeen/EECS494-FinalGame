using UnityEngine;
using System.Collections;

public class StaticScript : MonoBehaviour {	
	private float x=0;
	private float y=1;
	public int columns = 2;
	public int rows = 3;
	public int fps = 10;
	private Vector2 size;
	private Renderer myRenderer;
	private int lastIndex = -1;
	private Vector3 fwd;
	private Color fadeLevel;
	private RespawnTimer timer;
	void Start (){
		timer = GameObject.Find("Player").GetComponent<RespawnTimer>();
		myRenderer = renderer;
		if(myRenderer == null) enabled = false;
		size = new Vector2 (1.0f / columns ,1.0f / rows);
		myRenderer.material.SetTextureScale ("_MainTex", size);

		fadeLevel = myRenderer.material.color;
		fadeLevel.a = 0;
		myRenderer.material.color = fadeLevel;
	}
	void Update() {
		fadeLevel = myRenderer.material.color;
		fadeLevel.a = (1-timer.timeLeft/timer.timeLimit);	
		myRenderer.material.color = fadeLevel;

		int index = (int)(Time.time * fps) % (columns * rows);
		if(index != lastIndex) {
			Vector2 offset = new Vector2(x*size.x, 1-(size.y*y));
			x++;
			if(x >= columns) {
				x = 0;
				y++;
				if(y >= rows) {
					y = 0;
				}
			}

			myRenderer.material.SetTextureOffset ("_MainTex", offset);
			lastIndex = index;
		}
	}
}

