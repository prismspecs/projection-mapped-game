using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {

		//GetComponent<Rigidbody2D> ().AddExplosionForce (10f, transform.position, 3f, 0, ForceMode2D.Impulse);

		Destroy (this.gameObject);
		Instantiate(Explosion, transform.position, Quaternion.identity);

	}
}