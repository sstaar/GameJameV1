using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGirl : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private	GameObject	girl;
	private GirlMovement girlMov;
	private Animator	anim;

	void Start () {
		girl = GameObject.Find("Girl");
		girlMov = girl.GetComponent<GirlMovement>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Girl")
		{
			girlMov.girlSpeed = 0f;
			Destroy(this.gameObject);
		}
	}*/

	void	OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Girl")
		{
			anim.SetBool("Des", true);
			//yield return new WaitForSeconds(3);
			girlMov.girlSpeed = 0f;
			Destroy(this.gameObject, 0.6f);

		}
	}

}