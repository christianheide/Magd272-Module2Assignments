using UnityEngine;
using System.Collections;

public class moveGround : MonoBehaviour {
	public float moveSpeed;
	bool leftMark, rightMark;

	void Start(){
		leftMark = true;
		rightMark = false;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x <= -3) {
			leftMark = true;
			rightMark = false;
		}
		if (leftMark == true) {//move right
			transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
		}
		if (transform.position.x >= .75) {
			leftMark = false;
			rightMark = true;
		}
		if (rightMark == true) {//move left
			transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
		}
	}
}
