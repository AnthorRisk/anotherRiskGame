using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
	GUITexture ChangeScreen; //�ı䳡����Ч��

	public float Fade_Time = 2.2f; //�����仯����ʱ��

	public bool isFadeOut = false;
	public bool isFadeIn = true;

	float time = 0.0f;

	void Start ()
	{
		//��ȡ���GUITexture��Ϊ��������
		ChangeScreen = GetComponent<GUITexture> ();
	}

	void Update ()
	{
		float timeToChange;
		Color c1;
		Color c2 = new Color (0, 0, 0, 0);

		//����Ϸ����ʱ������������Ӱ��Ч��
		if (isFadeOut == true)
		{
			time += Time.deltaTime;
			timeToChange = time / Fade_Time;
			c1 = new Color (0, 0, 0, 0.35f);

			//timeToChange ʱ���ڣ�GUITexture����ɫ��͸����Ϊ0��Ϊ͸����Ϊ0.35f��rgba�����һ����������͸���� 0~1
			ChangeScreen.color = Color.Lerp (c2,c1,timeToChange);

		}
        
		//����Ϸ��ʼʱ��������ȥ��Ӱ��Ч��
		if (isFadeIn == true)
		{
			time += Time.deltaTime;
			timeToChange = time / Fade_Time;
			c1 = new Color (0, 0, 0, 0.5f);

			//timeToChange ʱ���ڣ�GUITexture����ɫ��͸����Ϊ0.5f��Ϊ͸����Ϊ0
			ChangeScreen.color = Color.Lerp (c1,c2,timeToChange);
		}

		//��Ϸ�����У���չʾ����Ч��
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

	//����������Ӱ��Ч��
	public void FadeOut ()
	{
		isFadeOut = true;
	}

	//������ȥ��Ӱ��Ч��
	public void FadeIn ()
	{
		isFadeIn = true;
	}

}
