using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  measureAcceleration : MonoBehaviour
{
	int counter = 1;
	int sum = 0;
	bool isEating = true;

	[SerializeField] Text score;
	[SerializeField] Text score2;
	[SerializeField] Text score3;

	// Use this for initialization
	void Start ()
	{
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

		counter++;
		// 加速度センサの値を取得
		double valx = Input.acceleration.x;
		double valy = Input.acceleration.y;
		double valz = Input.acceleration.z;
		Vector3 val = Input.acceleration;


		if (-1.0 < valy && valy < -0.8) {
			sum += 1;
		}

		//score.text = val.ToString(); //sum.ToString(); //val.ToString();
		score2.text = valy.ToString ();
		score.text = sum.ToString ();
	}

	public void OnClick ()
	{
		Finish ();
	}

	public int Finish ()
	{
		
		isEating = false;
		var result = 100 * sum / counter;
		score3.text = "SCOREは" + result.ToString ();
		return result;
	}
}
