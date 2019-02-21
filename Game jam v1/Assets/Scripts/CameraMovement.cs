using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private GameObject girl;

	[SerializeField]
	private GameObject cam;

	void Start () {
		//cam = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CamMove();
	}

	void	CamMove()
	{
		cam.transform.position = new Vector3(girl.transform.position.x + 10.45f, transform.position.y, -10);
	}

}
