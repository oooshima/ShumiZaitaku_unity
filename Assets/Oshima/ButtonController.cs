using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	 [SerializeField] GameObject usagi;

	//public static bool eatflag = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartButton(){
		SceneManager.LoadScene ("Maesure");
		Debug.Log("start");
	}

	public void EatButton(){
		Debug.Log("eat");
		usagi.GetComponent<UsagiEvolution>().Evolution();
	}
}
