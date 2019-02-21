using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization

	static bool exit;

	void Start () {
		DontDestroyOnLoad(this.gameObject);
		if (exit == true)
			Destroy(this.gameObject);
		else
			exit = true;
	}
	
	// Update is called once per frame
	void Update () {

	}


}
