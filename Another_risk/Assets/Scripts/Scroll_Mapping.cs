using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{

    public float ScrollSpeed = 0.45f;  //���ó�ʼ�ٶ�
    float temp; //������ʱ��仯�ı���

    void Start()
    {

    }

    //ÿһ֡����
    void Update()
    {
        Settemp(); //���ñ�������
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(temp, 0.02f);

    }

    // ��������ʱ��仯
    void Settemp()
    {
        temp = temp + Time.deltaTime * ScrollSpeed;
    }

    //���ó�ʼ�ٶ�
    void SetScrollSpeed()
    {
        ScrollSpeed = 0.45f;
    }
}
	
