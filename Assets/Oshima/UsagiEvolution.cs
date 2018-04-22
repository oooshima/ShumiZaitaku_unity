using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsagiEvolution : MonoBehaviour
{
 public static int carrot =50;//これまで食べた人参
static int level = 0;
int[] requireCarrot = new int[]{ 1, 2, 4, 8 };
 Animator _animator;
 public AnimatorClipInfo clipInfo;
 public AudioClip evolutionSound;
 private AudioSource audioSource;
 [ SerializeField] Text NinjinCount;
 
 


 void Start ()
 {
	_animator = GetComponent<Animator>();
	_animator.Play("idle");
	audioSource = gameObject.GetComponent<AudioSource> ();
  	DontDestroyOnLoad(this);
 }


 void Update ()
 {
	NinjinCount.text = ("にんじん:"+carrot+"ほん");
	clipInfo = _animator.GetCurrentAnimatorClipInfo (0)[0];
  	
	  if(clipInfo.clip.name == "JKidle"){
				UsagiMove.evolution = false;
			}
		if(clipInfo.clip.name == "OLidle"){
				UsagiMove.evolution = false;			
			}

  	if(Input.GetKeyUp(KeyCode.UpArrow)){
	  level++;
	
	  //Playsound();
   }
 }

public void Evolution(){
	Debug.Log(level);
	Debug.Log("lv, requireCarrot[level] = " + level + ", " + requireCarrot[level]);
	if (carrot >= requireCarrot[level]){
		Debug.Log("oooooshima dayo");
		  carrot -= requireCarrot[level];
		  level++;
	  }
	  	if(level == 1){
			StartCoroutine(UpdateEvolution());
			 _animator.SetInteger("count", 1);
			 level++;	
		  }
		if(level == 3){
			StartCoroutine(UpdateEvolution());
			_animator.SetInteger("count", 2);
			level++;	
		}
 }

public void Playsound(){
	audioSource.PlayOneShot (evolutionSound);
}

private IEnumerator UpdateEvolution(){
	yield return new WaitForSeconds(0.2f);
	UsagiMove.evolution = true;
}
}