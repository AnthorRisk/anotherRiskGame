using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk_Hit : MonoBehaviour {

	//sound effects player
	public Sound_Player _SP;
	public Disk_Factory _DF;
	//player acction manager
	//
	public Player_Move _PM;
	//the get coin nums
	//controller
	public Game_Manager _gm;
	//
	public Fade _fade;
	void Start()
	{
		//找到控制器对象，和场景对象
		GameObject a = GameObject.Find("05_GameManager");

		if(a!=null)
		{
			_gm = a.GetComponent<Game_Manager>();
			_DF = _gm.GetComponent<Disk_Factory> ();
		}
			
		GameObject b = GameObject.Find("Black_Screen");

		if(b!=null)
		{
			_fade = b.GetComponent<Fade>();
		}

	}
	void OnTriggerEnter (Collider Get)
	{
		//这个DeathZone是不可见的，谓语游戏底部的用于判断是否回收飞碟
		if (Get.tag == "DeathZone" || Get.tag == "Tile")
		{
			Debug.Log ("free disk");
			this.gameObject.SetActive (false);
			_DF.freeDisk (this.gameObject);
		}
	}
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

}
	