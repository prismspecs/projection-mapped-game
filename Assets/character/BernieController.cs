using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BernieController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.4f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	Animator anim;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;

		// if were in regular play mode, freeze Bernie in center screen

		anim = GetComponent<Animator>();

	}
	
	void FixedUpdate () {

		// hey, are we on the ground?
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

			
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
	
		//rigidbody2D.velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();


	}

	void Update() {
		if (grounded && Input.GetButtonDown ("Jump")) {
			grounded = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}

		// peace!
		if (grounded && Input.GetButtonDown ("Fire2")) {
			anim.SetTrigger ("peace");
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}