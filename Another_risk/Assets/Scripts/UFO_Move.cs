using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UFOStatus
{
	Move,
	Destroy
};

public class UFO_Move : MonoBehaviour
{
	
	public UFOStatus status;
	public Sprite_Animation _SA;
	public int flag = 0;
	public float x = 2;
	public float y = 1;

	static Bounds bound = new Bounds(new Vector3(2, 1, 0), new Vector3(15, 15, 1));
	Vector3 c = bound.center;
	Vector3 s = bound.size;

	void Start ()
	{
	
	}

	void Update ()
	{
		Judge ();
		GetComponent<Rigidbody>().WakeUp ();
	}

	void FLY ()
	{
		status = UFOStatus.Move;

		if ((gameObject.transform.position.x - x) <= 0.1 && (gameObject.transform.position.y - y) <= 0.1)
		{
			x = Random.Range (c.x - s.x * 0.5f, c.x + s.x * 0.5f);
			y = Random.Range (c.y - s.y * 0.5f, c.y + s.y * 0.5f);
		}

		Vector3 startpoint = new Vector3(transform.position.x,transform.position.y,transform.position.z); //起点
		Vector3 endpoint = new Vector3(x,y,transform.position.z); //终点

		transform.position = Vector3.Lerp(startpoint,endpoint,Time.deltaTime / 1f);  //移动

		//transform.Translate((x - gameObject.transform.position.x) * 0.012f, 0, -(y - gameObject.transform.position.y) * 0.012f);
		/*Debug.Log (gameObject.transform.position.x + "," + x);
		  Debug.Log (gameObject.transform.position.y + "," + y);*/
	}
	
	void Judge()
	{
		//if (status != UFOStatus.Destroy) {
		//	FLY ();
		//} else {
			//gameObject.SetActive (false);
			FLY ();
		//}
	}

	void OnTriggerEnter (Collider Get)
	{
		if (Get.tag == "Tile")
		{
			Debug.Log (",");
			status = UFOStatus.Destroy;
		}
	}

}
