using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsagiEvolution : MonoBehaviour
{
 public static int carrot;//これまで食べた人参
 public static int level;
 public int[] requireCarrot = new int[]{ 1, 1 };
 //public Image[] img = new Image;//ここにレベル１〜３の3枚の画像を入れる

 void Start ()
 {
  DontDestroyOnLoad(this);
  level = 0;
  carrot = 0;
 }
 void Update ()
 {
  if (carrot == requireCarrot [level])
  {
   carrot = 0;
   level++;
   //Image img = transform.Find ("name").transform as Image;
   //img.sprite = //ここに画像入れて〜
  }
 }
}