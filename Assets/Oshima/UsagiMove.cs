using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsagiMove : MonoBehaviour {
	
	private int AnimationNumber = 0;
	private float time;
	private float interval = 3.0f;
	public static bool evolution = false;
	
	Rigidbody2D rb;
	private Vector2 usagi_pos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > interval){
			AnimationNumber = (int)Random.Range(0.0f,5.0f);
			time = 0.0f;
		}
		//Debug.Log(AnimationNumber);
		//Debug.Log(evolution);
	if(evolution == true){
		transform.position = new Vector2(375f,900f);
		//evolution = false;
	}else{
		switch(AnimationNumber){
			case 0:
				usagi_pos = new Vector2(0.0f, 0.0f);
				//print("idle");
				break;
			case 1:
				usagi_pos = new Vector2(rb.velocity.x, 1.0f);
				//print("up");
				break;
			case 2:
				usagi_pos = new Vector2(rb.velocity.x, -1.0f);
				//print("down");
				break;
			case 3:
				usagi_pos = new Vector2(1.0f, rb.velocity.y);
				//print("right");
				break;
			case 4:
				usagi_pos = new Vector2(-1.0f, rb.velocity.y);
				//print("left");
				break;
			default:
            	print ("else");
            	break;
		}
	transform.Translate(usagi_pos);
	Clamp();
		}
	}

	void Clamp()
    {
        float x = Mathf.Clamp(transform.position.x, 10f, 740f); //x位置が常に範囲内か監視
		float y = Mathf.Clamp(transform.position.y, 620f, 1200f);
		transform.position = new Vector2(x,y);
    }

}
