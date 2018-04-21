using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeasureSceneController : MonoBehaviour {

	[SerializeField] private GameObject resultPanel;
	[SerializeField] private GameObject resultCarrots;
	[SerializeField] private GameObject measureSystem;
	[SerializeField] private Text pointText;

	// Use this for initialization
	void Start () {
		resultPanel.SetActive(false);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int Score(int rate) {
		return rate / 20 + 1;
	}

	public void OnClickStopButton() {
		resultPanel.SetActive(true);
		int score = Score(measureSystem.GetComponent<Measure>().Finish());
		foreach (Transform t in resultCarrots.transform) {
			if (Int32.Parse(t.name.Substring(6)) <= score) t.gameObject.SetActive(true);
			else t.gameObject.SetActive(false);
		}
		Debug.Log("score = " + score);
		pointText.text = "にんじんを " + score.ToString() + " ほん かくとくした！";
		UsagiEvolution.carrot += score;
		Debug.Log("UsagiEvolution.carrot = " + UsagiEvolution.carrot);
	}

	public void OnClickReturnButton() {
		SceneManager.LoadScene("Oshima");
	}
}
