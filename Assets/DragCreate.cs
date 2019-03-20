using UnityEngine;
using System.Collections;

public class DragCreate : MonoBehaviour {

	public Transform cubeObject;
	public GameObject bead;
	public float absoluteZPosition = 0f;
	public float absoluteZScale = 0.5f;
	private Transform activeObject;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 position = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		position.z = absoluteZPosition;

		// Left-Click
		if( Input.GetMouseButtonDown(0) ) {
			activeObject = Instantiate( cubeObject, position, Quaternion.identity ) as Transform; 
			startPosition = position;

			Form ( activeObject, startPosition, position );
		}

		if( Input.GetMouseButton(0) ) {
			Form ( activeObject, startPosition, position );
		}

		if( Input.GetMouseButtonUp(0)) {
			// done drawing shape
			activeObject.SendMessage("DoneDrawing");
		}
			
		// Right-Click
		if( Input.GetMouseButtonDown(1) ) {
			Instantiate( bead, position, Quaternion.identity );    
		}
	}

	private void Form( Transform shape, Vector3 start, Vector3 end ) {
		Vector3 scale = end - start;
		scale.z = absoluteZScale;

		Vector3 pos = start + scale/2;
		pos.z = absoluteZPosition;

		shape.position = pos;
		shape.localScale = scale;
	}
}