using UnityEngine;
using System.Collections;

public class humanMove : MonoBehaviour {
	Rigidbody2D charRB;
	Transform charTransform;
	float hFactor;
	public float hScale;
	float vVelocity;
	public float jumpVal;

	int counter = 0;
	bool grounded = true;

	bool facingRight = true;
	Animator anim;

	// Use this for initialization
	void Start () {
		charTransform = gameObject.transform;
		charRB = gameObject.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		//horizontal movement code
		hFactor = Input.GetAxis ("Horizontal") * hScale;
		anim.SetFloat ("hSpeed", Mathf.Abs (hFactor));

		//flip sprite code
		if (hFactor > 0 && !facingRight) {
			flip();
		}else if(hFactor < 0 && facingRight){
			flip();
		}

		//jump code
		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			counter += 1;
			vVelocity = jumpVal;
			charRB.velocity += new Vector2 (0, vVelocity);
			Debug.Log (counter);
			if (counter == 2) {
				grounded = false;
				vVelocity = 0;
				StartCoroutine ("ResetJump");
			}
		}

		charTransform.position = new Vector2(hFactor + charTransform.position.x, charTransform.position.y);
	}
	IEnumerator ResetJump(){
		yield return new WaitForSeconds (1.5f);
		counter = 0;
		vVelocity = 0;
		charRB.velocity += new Vector2 (0, vVelocity);
		grounded = true;
		Debug.Log (counter);
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1.0f;
		transform.localScale = theScale;
	}

}
