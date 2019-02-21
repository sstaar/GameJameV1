using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovement : MonoBehaviour {

	// Use this for initialization

	private Rigidbody2D rb;

	[SerializeField]
	private float speed;

	[SerializeField]
	private GameObject cam;

	[SerializeField]
	private float jumpForce;

	private int 	grounded;

	[SerializeField]
	private Animator anim;

	private int dir;

	[SerializeField]
	private GameObject	moveSound;

	void Start () {
		rb	= GetComponent<Rigidbody2D>();
		grounded = 1;
		cam = GameObject.Find("Main Camera");
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dir == 0)
			moveSound.SetActive(false);
		else if (grounded == 0)
			moveSound.SetActive(false);
		else if ((dir == 1 || dir == -1) && grounded == 1)
			moveSound.SetActive(true);
		Jump();
		Move();
	}


	void	Move()
	{

		if (Input.GetAxisRaw("Horizontal") > 0 && rb.transform.position.x <= cam.transform.position.x + 12.24f)
		{
			anim.SetBool("Walk",true);
			anim.SetBool("Idle", false);
			rb.transform.rotation = Quaternion.Euler(0, 0, 0);
			dir = 1;
		}
		else if (Input.GetAxisRaw("Horizontal") < 0 && rb.transform.position.x >= cam.transform.position.x - 12.24f)
		{
			anim.SetBool("Walk",true);
			anim.SetBool("Idle", false);
			rb.transform.rotation = Quaternion.Euler(0, 180, 0);
			dir = -1;
		}
		else
		{
			anim.SetBool("Walk",false);
			anim.SetBool("Idle", true);
			dir = 0;
		}
		rb.velocity = new Vector2 (speed * dir, rb.velocity.y);
	}

	IEnumerator	JumpAudio()
	{
		GameObject temp = (GameObject)Instantiate(Resources.Load("JumpSound"));
		yield return new WaitForSeconds(0.3f);
		Destroy(temp);
	}

	void	Jump()
	{
		if (Input.GetButtonDown("Jump"))
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce * grounded);
			if (grounded == 1)
				StartCoroutine(JumpAudio());
			grounded = 0;
		}
		//rb.velocity = new Vector2(rb.velocity.x, /*rb.velocity.y + */(jump * 10));
	}

    void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
			grounded = 1;
	}


}
