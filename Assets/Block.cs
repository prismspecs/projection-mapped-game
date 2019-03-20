using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.X)) {

			Transform followmouse = GameObject.Find ("follow mouse").transform;

			float dist = Vector2.Distance (followmouse.position, transform.position);

			Debug.Log (dist);

			if (dist < 1f) {


				Destroy (this.gameObject);
			}

		}
	}

	public void DoneDrawing() {
		float x = rend.bounds.size.x;
		float y = rend.bounds.size.y;
		float z = rend.bounds.size.z;

		// if im hella small just delete me
		float area = x*y*z;
		if(area < .02) Destroy(this.gameObject);

	}

	void OnMouseDown() {
		// this object was clicked - do something
//		if (Input.GetKey (KeyCode.X)) {
//
//			Transform followmouse = GameObject.Find ("follow mouse").transform;
//
//			float dist = Vector2.Distance (followmouse.position, transform.position);
//
//			Debug.Log (dist);
//
//			if (dist < 1f) {
//				
//			
//				Destroy (this.gameObject);
//			}
//
//		}
	}
}
