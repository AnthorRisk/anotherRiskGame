using UnityEngine;
using System.Collections;

public class Box_Loop : MonoBehaviour 
{

	public float Speed = 4.5f;

	public GameObject[] Box; //����

	public GameObject A_Box; //����A����

	public GameObject B_Box; //����B����
	
	void Update ()
	{
		MoveForward();
	}
	

	public GameObject MakeBox()
	{
		
		GameObject x_Box;

		//���ѡ��ͬ�ĵ���������ʵ������������Ϸ�����Ķ�����
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
		//����ָ�����壬ʵ�����µĵ������
		Destroy(b_Box);

		GameObject temp_Box;
		temp_Box = MakeBox();
		SetBox(temp_Box);

	}

	public void MoveForward()
	{
		
		//�����������ϵ����������尴һ���ٶ�����ƽ��
		float speed = Speed *Time.deltaTime;
		A_Box.transform.Translate(Vector3.left * speed,
			Space.World);
		
		B_Box.transform.Translate(Vector3.left * speed,
            Space.World);

		TimeToUpdate(A_Box);
	   
	}

	void TimeToUpdate(GameObject A_Box)
	{
		//������A���峬��x=0��λ�ã���B�������
		if(A_Box.transform.position.x <= 0)
		{
			Death(B_Box);
		}
	}
	

}
