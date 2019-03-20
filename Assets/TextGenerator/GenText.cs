using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenText : MonoBehaviour {

	public string TheText;
	public GameObject CharacterObject;
	public float CharacterSpacing = .2f;
	public bool DropFromMouse = true;
	public string Key = "v";

	public Vector3 DropFrom;

	void DropText () {

		if (DropFromMouse) {
			Vector3 WorldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3 (WorldMouse.x, WorldMouse.y, 0);
			DropFrom = WorldMouse;
		}

		float lastTextWidth = 0f;

		for (int i = 0; i < TheText.Length; i++) {

			Vector3 xOffset = new Vector3 (lastTextWidth, 0, 0);

			GameObject NewCharacter = (GameObject)Instantiate (CharacterObject, transform.position + xOffset, Quaternion.identity);

			NewCharacter.GetComponent<TextMesh> ().text = TheText[i].ToString();

			Bounds textBounds = NewCharacter.GetComponent<Renderer>().bounds;
			lastTextWidth = Mathf.Abs(textBounds.max.x - transform.position.x) + .2f;

			NewCharacter.GetComponent<BoxCollider2D> ().size = new Vector2 (Mathf.Abs(textBounds.max.x - textBounds.min.x), Mathf.Abs(textBounds.max.y - textBounds.min.y));

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(Key))
			DropText ();
	}
}
