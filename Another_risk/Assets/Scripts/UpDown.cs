using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour
{
	
	public float Speed;
	public float ChangeTime;

	public float Up_Position; //对象升起的位置
	public float Down_Position; //对象降落的位置

	public bool UpOrDown = true; //判断是否要升降

	float time;
	
	void Start ()
	{
		
		Up_Position += transform.position.y;
		Down_Position = transform.position.y;
	}
	
	void Update ()
	{
		TimeChange(); //时间推移

		Vector3 startpoint = new Vector3(transform.position.x,transform.position.y,transform.position.z); //起点

		if (UpOrDown == true)
		{

			Vector3 endpoint = new Vector3(transform.position.x,Up_Position,transform.position.z); //终点

			transform.position = Vector3.Lerp(startpoint,endpoint,Time.deltaTime / Speed);  //向上移动

			changeStatus(false);  //状态改变

		} 

		else if (UpOrDown == false)
        {
			Vector3 endpoint = new Vector3(transform.position.x,Down_Position,transform.position.z); //终点

			transform.position = Vector3.Lerp(startpoint,endpoint,Time.deltaTime / Speed);  //向下移动

			changeStatus(true); 

		}
		
	}

	//时间函数
	void TimeChange() 
	{

		time += Time.deltaTime;
	}

	//状态函数
	void changeStatus(bool b)
	{
		if (time >= Speed)
		{
			time = 0;
			UpOrDown = b;
		}
	}
}
