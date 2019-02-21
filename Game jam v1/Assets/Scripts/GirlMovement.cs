using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour {

	// Use this for initialization

	private Rigidbody2D rb;

	public float  girlSpeed;

	[SerializeField]
	private	GameObject	girlMoveSound;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ConstMove();
		if (girlSpeed == 0)
			girlMoveSound.SetActive(false);
		else
			girlMoveSound.SetActive(true);
	}

	void	ConstMove()
	{
		rb.velocity = new Vector2(girlSpeed, rb.velocity.y);
	}

}
