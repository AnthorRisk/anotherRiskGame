using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
	GUITexture ChangeScreen; //改变场景的效果

	public float Fade_Time = 2.2f; //场景变化持续时间

	public bool isFadeOut = false;
	public bool isFadeIn = true;

	float time = 0.0f;

	void Start ()
	{
		//获取组件GUITexture作为场景遮罩
		ChangeScreen = GetComponent<GUITexture> ();
	}

	void Update ()
	{
		float timeToChange;
		Color c1;
		Color c2 = new Color (0, 0, 0, 0);

		//当游戏结束时，场景加入阴影的效果
		if (isFadeOut == true)
		{
			time += Time.deltaTime;
			timeToChange = time / Fade_Time;
			c1 = new Color (0, 0, 0, 0.35f);

			//timeToChange 时间内，GUITexture的颜色从透明度为0变为透明度为0.35f，rgba的最后一个参数代表透明度 0~1
			ChangeScreen.color = Color.Lerp (c2,c1,timeToChange);

		}
        
		//当游戏开始时，场景褪去阴影的效果
		if (isFadeIn == true)
		{
			time += Time.deltaTime;
			timeToChange = time / Fade_Time;
			c1 = new Color (0, 0, 0, 0.5f);

			//timeToChange 时间内，GUITexture的颜色从透明度为0.5f变为透明度为0
			ChangeScreen.color = Color.Lerp (c1,c2,timeToChange);
		}

		//游戏进行中，不展示遮罩效果
		if (time >= Fade_Time)
		{
			time = 0;
			notFadeIn();
			notFadeOut();
		}
	}

	void notFadeOut ()
	{
		isFadeOut = false;
	}

	void notFadeIn ()
	{
		isFadeIn = false;
	}

	//场景加入阴影的效果
	public void FadeOut ()
	{
		isFadeOut = true;
	}

	//场景褪去阴影的效果
	public void FadeIn ()
	{
		isFadeIn = true;
	}

}
