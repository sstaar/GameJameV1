using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour {

	[SerializeField]
	private Vector3	finish;

	[SerializeField]
	private	float	speed;

	[SerializeField]
	private	Transform	pos;

	public	bool	move;

	private	MoveGirl	girl;

	// Use this for initialization
	void Start () {
		pos = GetComponent<Transform>();
		move = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true)
			MovePlat();
		if (transform.position == finish)
			move = false;
	}

	void	MovePlat()
	{
		if (transform.position.x < finish.x)
			pos.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		if (transform.position.y < finish.y)
			pos.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
		if (transform.position.x > finish.x)
			pos.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		if (transform.position.y > finish.y)
			pos.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
	}

	private	IEnumerator	stop(GirlMovement girl)
	{
		yield return new WaitForSeconds(0.1f);
		girl.girlSpeed = 0;
	}

	/*void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Girl")
		{
			StartCoroutine(stop(coll.gameObject.GetComponent<GirlMovement>()));
		}
	}*/

}
