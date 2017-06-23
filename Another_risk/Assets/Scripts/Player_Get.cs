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
		
		//�ҵ���������
		GameObject bs = GameObject.Find("Black_Screen");

		//�ҵ����������󣬺ͳ�������
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

	//�������¼�����������������������ʱ��������Ҫ�����ı� 
	void OnTriggerEnter (Collider Get)
	{
		time += Time.deltaTime; 

		if (Get.tag == "disk")
		{
			decrease.text = "$ +5";
			time = 0.0f;

			Get.gameObject.SetActive(false);
			if (_gm != null)
				//������õ���Ϣ֪ͨ��ִ�еõ�Ӳ�Һ���
				_gm.LostCoinUFO (-5);

			if (_SP != null)
				//��һöӲ�Ҳ���һ����Ч
				_SP.SoundPlay (1);
			_gm.DF.freeDisk (Get.gameObject);
		}

        //�񵽽�ң����Ӧ����ʧ������õ������Ӧ�ü�һ
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
				//������õ���Ϣ֪ͨ��ִ�еõ�Ӳ�Һ���
				_gm.GetCoin ();
			}
			
			if (_SP != null)
			{
				//��һöӲ�Ҳ���һ����Ч
				_SP.SoundPlay (1);
			}
		}
		
		//���DeathZone�ǲ��ɼ��ģ�λ����Ϸ�ײ��������ж������Ƿ������Ķ���
		if (Get.tag == "DeathZone")
        {
			Debug.Log ("The player dies"); 
			if (_PM.status != PlayerMoveStatus.Die)
            {
				_PM.status = PlayerMoveStatus.Die;
				//���ʧ�ܺ����Ϸ�ı�
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
