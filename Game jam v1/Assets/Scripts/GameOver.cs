using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private	GameObject gm;
	private ResetGame res;

	void Start () {
		res = gm.GetComponent<ResetGame>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void	OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Girl" || coll.gameObject.tag == "Player")
			res.ResetGameButton();
	}

}
