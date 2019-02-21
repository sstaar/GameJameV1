using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

	[SerializeField]
	private GameObject plat;

	private MovingPlatFormToStop	mPlat;

	private Animator anim;

	// Use this for initialization
	void Start () {
		mPlat = plat.GetComponent<MovingPlatFormToStop>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void	OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			mPlat.reset = true;
			mPlat.move = false;
			anim.SetBool("Des", true);
			Destroy(this.gameObject, 0.6f);
		}
	}

}
