using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text lifeText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private int life;
	private bool gameOver;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		life = 3;
		SetLifeText ();
		gameOver = false;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (!gameOver) {
			if (other.gameObject.CompareTag ("Pick Up")) {
				other.gameObject.SetActive (false);
				count = count + 1;
				SetCountText ();
			}
			if (other.gameObject.CompareTag ("Post")) {
				other.gameObject.SetActive (false);
				life = life - 1;
				SetLifeText ();
			}
		}
	}

	//void OnCollisionEnter(Collision collision) {
		//foreach (ContactPoint contact in collision.contacts) {
		//	Debug.DrawRay(contact.point, contact.normal, Color.white);
		//}
		//if (other.gameObject.CompareTag ("Post")) 
		//{
		//	count = count - 1;
		//	SetCountText ();
		//}
	//}
		

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win!";
			gameOver = true;
		}
	}

	void SetLifeText()
	{
		lifeText.text = "lives: " + life.ToString ();
		if (life == 0) 
		{
			winText.text = "You Lose!";
			gameOver = true;
		}
	}
}