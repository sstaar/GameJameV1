using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatFormToStop : MonoBehaviour {

	private Vector3 start;
	[SerializeField]
	private Vector3	finish;

	[SerializeField]
	private	float	speed;

	[SerializeField]
	private	Transform	pos;

	public	bool	move;
	public	bool	reset;

	private	MoveGirl	girl;
	[SerializeField]
	private	float	time;


	private GameObject chara;

	// Use this for initialization
	void Start () {
		start = transform.position;
		move = false;
		reset = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true && reset == false)
			MovePlat();
		if(transform.position == finish)
			move = false;
		if(reset == true && move == false)
			ResetPlat();
		if(transform.position == start)
			reset = false;
		//StartCoroutine(Move(GameObject.Find("Girl").GetComponent<GirlMovement>()));

	}

	void	ResetPlat()
	{
		Debug.Log("Here");
		if (transform.position.x < start.x)
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		if (transform.position.y < start.y)
			transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
		if (transform.position.x > start.x)
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		if (transform.position.y > start.y)
			transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
	}

	void	MovePlat()
	{
		pos = chara.GetComponent<Transform>();

		if (transform.position.x < finish.x)
		{
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
			pos.position = new Vector3(pos.position.x + speed * Time.deltaTime, pos.position.y, pos.position.z);

		}
		if (transform.position.y < finish.y)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
			pos.position = new Vector3(pos.position.x, pos.position.y + speed * Time.deltaTime, pos.position.z);

		}
		if (transform.position.x > finish.x)
		{
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
			pos.position = new Vector3(pos.position.x - speed * Time.deltaTime, pos.position.y, pos.position.z);

		}
		if (transform.position.y > finish.y)
		{
			pos.position = new Vector3(pos.position.x, pos.position.y - speed * Time.deltaTime, pos.position.z);
			transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
		}	
	}

	private		void	StartIt()
	{
		if (transform.position != finish)
			StartCoroutine(Move(GameObject.Find("Girl").GetComponent<GirlMovement>()));

	}

	private	IEnumerator	StopGirl(GirlMovement girl)
	{
		
		yield return new WaitForSeconds(0.1f);
		Debug.Log("NNN");
		girl.girlSpeed = 0;
		move = true;
		yield return new WaitForSeconds(time);
		girl.girlSpeed = 2;
	}

		private	IEnumerator	StopBoy()
	{
		yield return new WaitForSeconds(0.2f);
		//girl.girlSpeed = 0;
				move = true;
	}

	private	IEnumerator	Move(GirlMovement girl)
	{
		yield return new WaitForSeconds(0.3f);
		girl.girlSpeed = 2;

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
					Debug.Log("works!");

		if (coll.gameObject.tag == "Girl" && transform.position != finish)
		{
			chara = coll.gameObject;
			Debug.Log("works!");
			reset = false;
			StartCoroutine(StopGirl(coll.gameObject.GetComponent<GirlMovement>()));
		}
		else if (coll.gameObject.tag == "Player" && transform.position != finish)
		{
			reset = false;
			chara = coll.gameObject;
			Debug.Log("works!");
			StartCoroutine(StopBoy());
		}
		if (coll.gameObject.tag == "Girl" && transform.position.y == finish.y && transform.position.x == finish.x)
		{
			Debug.Log("HAHA");
			StartCoroutine(Move(coll.gameObject.GetComponent<GirlMovement>()));
		}
	}
}

