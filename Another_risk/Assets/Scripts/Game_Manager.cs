using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//枚举游戏状态，玩、暂停、结束
public enum GameState
{
	Play,
	Pause,
	End,
}

public class Game_Manager : MonoBehaviour
{
	public GameState gamestate; //游戏状态
	public int GameLevel;      //游戏层次
	public float GameSpeed;    //游戏速度

	public Box_Loop BL;
	public Scroll_Mapping SM;
	public Disk_Factory DF;
	public CCActionManager AM;
	public float meter;   //玩家前进的距离
	public int money = 0;  //玩家获取的金币


    //GUI
	public GUITexture Change_screen;

	public GUIText Money_Label;   //金币
	public GUIText Meter_Label;   //距离
	public GUIText Money_Label_result;
	public GUIText Meter_Label_result;

	public Fade fade;

	GUIStyle guiRectStyle;


    //按钮
	public Texture Pause_btn; //暂停
	public Texture Go_btn;    //继续
	public Texture Replay_btn; //重新开始
	public Texture Main_btn;
	public GameObject result_window;

	float screenX;
	float screenY;
	float time = 0;

	void Start ()
	{		
		GameObject box2 = GameObject.Find("02_Box_Maker"); //获取Box场景
		GameObject sky = GameObject.Find("01_Sky");        //获取天空场景

		if(box2 != null)
		{
            BL = box2.GetComponent<Box_Loop>();
		}
       
		if(sky != null)
		{
			SM = sky.GetComponent<Scroll_Mapping>();
		}

		AM = this.GetComponent<CCActionManager> ();
		DF = this.GetComponent<Disk_Factory> ();
		GameSpeed = BL.Speed;		
		ScreenSetting ();
	}


	/// /设置图形用户界面样式
	void ScreenSetting ()
	{
		float screenXOff = Screen.width;  //左右偏移
		float screenYOff = Screen.height; //上下偏移

		screenX = screenXOff * 0.5f;  
		screenY = screenXOff * 0.5f;  

		guiRectStyle = new GUIStyle ();
		guiRectStyle.border = new RectOffset (0, 0, 0, 0);

		fade.FadeIn ();
	}

	void Update ()
	{
		if (gamestate == GameState.Play)
		{
			GameObject UFO = GameObject.Find ("UFO");
			UFO.GetComponentInChildren<TextMesh> ().text = "";

			GameObject disk;
			time += Time.deltaTime;
			if (time > 0.7) {            //获取飞碟金币
			    disk = DF.getDisk ();
				AM.StartGame (disk);
				time = 0;	
				Debug.Log (disk.GetComponent<Disk_Data>().score);
			}
			MeterUpdate ();
		}

	}
	

	void OnGUI ()
	{
		////在游戏过程中，玩家可以点击暂停按钮来暂停游戏
		if (gamestate == GameState.Play)
        {
			
			////Rect的四个参数分别为left top right bottom
			if (GUI.Button (new Rect (20, 20, Pause_btn.width, Pause_btn.height),
                Pause_btn,
				guiRectStyle))
            {
				Time.timeScale = 0; //暂停游戏
				Change_screen.color = new Color (0, 0, 0, 0.35f);
				gamestate = GameState.Pause; 
			}
		}


		/////游戏暂停时
		if (gamestate == GameState.Pause)
        {

			///点击replay按钮，游戏重新开始
			if (GUI.Button (new Rect (screenX - Replay_btn.width * 0.5f,
                screenY - Replay_btn.height * 0.9f - 110f, 
                Replay_btn.width, Replay_btn.height),
                Replay_btn,
                guiRectStyle))
            {
				Time.timeScale = 1; //恢复游戏
                SceneManager.LoadScene ("[PlayScene]");
            }

			////点击continue按钮，游戏继续
			if (GUI.Button (new Rect (screenX - Go_btn.width * 0.5f,
				screenY + Replay_btn.height * 0.2f - 120f,
				Go_btn.width, Go_btn.height),
				Go_btn,
				guiRectStyle))
			{
				Time.timeScale = 1; ///恢复游戏
				Change_screen.color = new Color (0, 0, 0, 0);
				gamestate = GameState.Play;

			}

			///点击exit按钮，退出游戏，回到游戏结束的界面，无法点击continue
			if (GUI.Button (new Rect (screenX - Main_btn.width * 0.5f,
				screenY - Replay_btn.height * 0.9f - Main_btn.height - 110f,
                Main_btn.width, Main_btn.height),
                Main_btn,
                guiRectStyle))
            {
				gamestate = GameState.End;
				//fade.FadeOut ();
                //Application.Quit();
			}
		}

		///当游戏结束时，
		if (gamestate == GameState.End) {
			///点击replay按钮，重新开始游戏
			if (GUI.Button (new Rect (screenX - Replay_btn.width * 0.5f,
				screenY - 150f, Replay_btn.width,
                Replay_btn.height),
                Replay_btn,
                guiRectStyle))
            {
				Time.timeScale = 1; //恢复游戏
                SceneManager.LoadScene("[PlayScene]");
            }

			//点击exit按钮，退出游戏
			if (GUI.Button (new Rect (screenX - Main_btn.width * 0.5f, 
				screenY + Replay_btn.height - 150f,
				Main_btn.width, Main_btn.height),
				Main_btn,
				guiRectStyle))
			{
				Debug.Log("exit game!!");
                Application.Quit();
            }
		}
	}
    ///游戏结束时，显示游戏结果
	public void GameOver ()
	{
		gamestate = GameState.End;
		fade.FadeOut ();
		result_window.gameObject.SetActive (true);
		Meter_Label_result.text = string.Format ("{0:N0}", meter); 
		Money_Label_result.text = string.Format ("{0:N0}", money);

	}
		
	//玩家吃到金币，则金币值增加

	public void GetCoin ()
	{
		money += 1;
		Money_Label.text = string.Format ("{0:N0}", money);
	}
	//射击获得金币
	public void GetCoinShoot (int num)
	{
		money += num;
		Money_Label.text = string.Format ("{0:N0}", money);
	}

	////玩家撞到飞碟障碍，金币值减少
	public void LostCoinUFO (int num)
	{
		money -= num;
		Money_Label.text = string.Format ("{0:N0}", money);
	}

	// 射击消耗金币
	public void LostCoinShoot (int num)
	{
		money -= num;
		Money_Label.text = string.Format ("{0:N0}", money);
	}

	//当玩家玩到一定距离时，游戏加速
	public void MeterUpdate ()
	{
		meter += Time.deltaTime * GameSpeed;

		Meter_Label.text = string.Format ("{0:N0}<color=#ff3366> m</color>", meter);

		if (meter >= 100 && GameLevel == 1)
		{
			GameLevelUp ();
		}

		if (meter >= 200 && GameLevel == 2)
		{
			GameLevelUp ();
		}

		if (meter >= 300 && GameLevel == 3)
		{
			GameLevelUp ();
		}

		if (meter >= 400 && GameLevel == 4)
		{
			GameLevelUp ();
		}

		if (meter >= 500 && GameLevel == 5)
		{
			GameLevelUp ();
		}

		if (meter >= 600 && GameLevel == 6)
		{
			GameLevelUp ();
		}

		if (meter >= 800 && GameLevel == 7) 
		{
			GameLevelUp ();
		}
	}

	 //加大游戏难度
	public void GameLevelUp ()
	{
		GameLevel += 1;
		GameSpeed += 2;

		BL.Speed = GameSpeed;
		SM.ScrollSpeed += 0.1f;
	}
}
