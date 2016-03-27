using UnityEngine;
using System.Collections;

public class groundFall : MonoBehaviour {
	float fallValue;
	bool touching = false;

	
	// Update is called once per frame
	void Update () {
		if (touching == true) {
			fallValue += -.001f;
			transform.position = new Vector2 (transform.position.x, transform.position.y + fallValue);
		}
	}

	void OnTriggerEnter2D(){
		touching = true;
	}
}
