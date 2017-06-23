using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{

    public float ScrollSpeed = 0.45f;  //设置初始速度
    float temp; //设置随时间变化的变量

    void Start()
    {

    }

    //每一帧更新
    void Update()
    {
        Settemp(); //调用变量函数
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(temp, 0.02f);

    }

    // 变量随着时间变化
    void Settemp()
    {
        temp = temp + Time.deltaTime * ScrollSpeed;
    }

    //设置初始速度
    void SetScrollSpeed()
    {
        ScrollSpeed = 0.45f;
    }
}
	
