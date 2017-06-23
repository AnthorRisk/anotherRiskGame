using UnityEngine;
using System.Collections;

public class Player_Get : MonoBehaviour
{
	//sound effects player
	public Sound_Player _SP;
	//player acction manager
	//
	public Player_Move _PM;
	//the get coin nums
	public int Get_Coin_Count;
	//controller
	public Game_Manager _gm;
	//
	public Fade _fade;

	public GUIText decrease;

	float time = 0.0f;

	void Start()
	{
		
		//找到场景遮罩
		GameObject bs = GameObject.Find("Black_Screen");

		//找到控制器对象，和场景对象
		GameObject gam = GameObject.Find("05_GameManager");

		if(bs != null)
		{
			_fade = bs.GetComponent<Fade>();
		}
			
		if(gam != null)
		{
            _gm = gam.GetComponent<Game_Manager>();
		}

		
	}

	//触发器事件，当人物碰到其他东西的时候，人物需要作出改变 
	void OnTriggerEnter (Collider Get)
	{
		time += Time.deltaTime; 

		if (Get.tag == "disk")
		{
			decrease.text = "$ +5";
			time = 0.0f;

			Get.gameObject.SetActive(false);
			if (_gm != null)
				//控制类得到消息通知，执行得到硬币函数
				_gm.LostCoinUFO (-5);

			if (_SP != null)
				//捡一枚硬币播放一次音效
				_SP.SoundPlay (1);
			_gm.DF.freeDisk (Get.gameObject);
		}

        //捡到金币，金币应该消失，人物得到金币数应该加一
		if (Get.tag == "coin")
        {	
			if (time >= 0.3f) 
			{
				decrease.text = "";
			}

			Get.gameObject.SetActive (false);
			Get_Coin_Count += 1;

			if (_gm != null)
			{
				//控制类得到消息通知，执行得到硬币函数
				_gm.GetCoin ();
			}
			
			if (_SP != null)
			{
				//捡一枚硬币播放一次音效
				_SP.SoundPlay (1);
			}
		}
		
		//这个DeathZone是不可见的，位于游戏底部的用于判断人物是否死亡的对象
		if (Get.tag == "DeathZone")
        {
			Debug.Log ("The player dies"); 
			if (_PM.status != PlayerMoveStatus.Die)
            {
				_PM.status = PlayerMoveStatus.Die;
				//玩家失败后的游戏改变
				this.gameObject.GetComponent<Rigidbody>().AddForce (0, -50f, 0);

				if (_fade != null)
				{
					_fade.FadeOut ();
				}

				if (_SP != null)
				{
					_SP.SoundPlay (2);
				}

				if (_gm != null)
				{
					_gm.GameOver ();
				}
			

			}
			
		}

		if (Get.tag == "UFO")
        {	
			Get_Coin_Count -= 10;
			if (_gm != null)
			{
				_gm.LostCoinUFO (10);
			}
			//Get.GetComponentInChildren<TextMesh>().text="$-10";
			decrease.text = "$-10"; 
			time = 0.0f;

			if (_SP != null)
			{
				_SP.SoundPlay (0);
			}
		}
	}
		
}
