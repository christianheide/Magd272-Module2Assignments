using UnityEngine;
using System.Collections;

public class birdMove : MonoBehaviour {
	float vFactor;

	Transform bTrans;
	bool inAir = false;

	Animator anim;


	// Use this for initialization
	void Start () {
		bTrans = gameObject.transform;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("flyHeight", vFactor);
		fly();
	}

	void fly(){
		if (Input.GetKey (KeyCode.UpArrow) && inAir == false && vFactor < 4) {
			vFactor += Time.deltaTime;
			bTrans.position = new Vector2 (bTrans.position.x, vFactor);
		} else if (vFactor >= 4) {
			vFactor += 0;
			bTrans.position = new Vector2 (bTrans.position.x, vFactor);
			StartCoroutine ("flyingTime");
		}
	
		if (inAir == true) {
			vFactor = 0;
			StartCoroutine ("resetFly");
		}
	}

	IEnumerator flyingTime(){
		yield return new WaitForSeconds (3.0f);
		inAir = true;
	}
	IEnumerator resetFly(){
		yield return new WaitForSeconds (1.5f);
		inAir = false;
	}
}
