using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsagiEvolution : MonoBehaviour
{
 public static int carrot;//これまで食べた人参
 public static int level = 0;
 public int[] requireCarrot = new int[]{ 1, 1 };
 Animator _animator;
 AnimatorClipInfo clipInfo;


 void Start ()
 {
	_animator = GetComponent<Animator>();
	_animator.Play("idle");
  	DontDestroyOnLoad(this);
 }
 void Update ()
 {
	clipInfo = _animator.GetCurrentAnimatorClipInfo (0)[0];
	if(ButtonController.eatflag == true){
	 // if (carrot == requireCarrot [level]){
		//  level++;
	 // }
	  	if(level == 1){
			UsagiMove.evolution = true;
			 _animator.SetInteger("count", 1);
			if(clipInfo.clip.name == "JKidle"){
				UsagiMove.evolution = false;
				ButtonController.eatflag = false;
			}
		  }
		if(level == 2){
			UsagiMove.evolution = true;
			_animator.SetInteger("count", 2);
			if(clipInfo.clip.name == "OLidle"){
				UsagiMove.evolution = false;
				ButtonController.eatflag = false;				
			}
		}
  	}

  if(Input.GetKeyUp(KeyCode.UpArrow)){
	  level++;
	  Debug.Log(level);
   }
 }
}