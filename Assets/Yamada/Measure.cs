﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  Measure : MonoBehaviour
{
	int counter = 1;
	int sum = 0;
	int badSum = 0;
	bool isEating = true;
	bool isMoving = false;
	float oldValy = 0.0f;

	// [SerializeField] Text score;
	// [SerializeField] Text score2;
	// [SerializeField] Text score3;

	// Use this for initialization
	void Start ()
	{
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 加速度センサの値を取得
		float valx = Input.acceleration.x;
		float valy = Input.acceleration.y;
		float valz = Input.acceleration.z;
		Vector3 val = Input.acceleration;

		if (isMoving == false) 
		{
			if (Mathf.Abs (oldValy - valy) > 0.1) 
			{
				StartCoroutine ("sleep");
				return;
			} 
		}

		if (isMoving == false) 
		{
			counter++;
			if (0.8 < Mathf.Abs(valy) && Mathf.Abs(valy) < 1.0) 
			{
				sum += 1;
			}
			else {
				badSum += 1;
				if (badSum > 200) {
					Debug.Log ("姿勢悪いよ");
					Handheld.Vibrate();
					if (SystemInfo.supportsVibration) print("振動対応");
					else print("振動非対応");
					badSum = 0;
				}
			}
		}

		oldValy = valy;
		// score2.text = counter.ToString ();
		// score.text = sum.ToString ();
	}

	public void OnClick ()
	{
		Finish ();
	}

	public int Finish ()
	{
		
		isEating = false;
		var result = 100 * sum / counter;
		// score3.text = "SCOREは" + result.ToString ();
		return result;
	}

	IEnumerator sleep ()
	{
		isMoving = true;
		yield return new WaitForSeconds (5);  
		isMoving = false;
	}
}
