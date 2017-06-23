using UnityEngine;
using System.Collections;

public class Box_Loop : MonoBehaviour 
{

	public float Speed = 4.5f;

	public GameObject[] Box; //地面

	public GameObject A_Box; //地面A块体

	public GameObject B_Box; //地面B块体
	
	void Update ()
	{
		MoveForward();
	}
	

	public GameObject MakeBox()
	{
		
		GameObject x_Box;

		//随机选择不同的地面块体进行实例化，增加游戏场景的多样性
		int ran = Random.Range(0,5);
		x_Box = Instantiate(Box[ran], new Vector3(30,0,0),transform.rotation) as GameObject;
		return x_Box;
		
	}

	public void SetBox(GameObject x_Box)
	{
		B_Box=A_Box;
		A_Box = x_Box;

	}

	public void Death(GameObject b_Box)
	{
		//消除指定块体，实例化新的地面块体
		Destroy(b_Box);

		GameObject temp_Box;
		temp_Box = MakeBox();
		SetBox(temp_Box);

	}

	public void MoveForward()
	{
		
		//相对世界坐标系，将地面块体按一定速度往左平移
		float speed = Speed *Time.deltaTime;
		A_Box.transform.Translate(Vector3.left * speed,
			Space.World);
		
		B_Box.transform.Translate(Vector3.left * speed,
            Space.World);

		TimeToUpdate(A_Box);
	   
	}

	void TimeToUpdate(GameObject A_Box)
	{
		//当地面A块体超出x=0的位置，则将B块体毁灭
		if(A_Box.transform.position.x <= 0)
		{
			Death(B_Box);
		}
	}
	

}
