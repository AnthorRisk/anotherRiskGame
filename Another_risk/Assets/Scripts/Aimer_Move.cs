using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Aimer_Move : MonoBehaviour
{
	public UFO_Move UFO;
	public Game_Manager _gm;
	public double ScaleX = 0.11f;
	public double ScaleZ = 0.11f;
	public bool  flag   = true;

	public GUIText UFOtext;

	float time = 0.0f;
	
	void Start ()
	{
	
	}

	void Update ()
	{
		time += Time.deltaTime;
		if (time >= 2.0f)
		{
			UFOtext.text = "";
		}

		transform.Rotate (0, 250 * Time.deltaTime, 0, Space.Self);

		if (flag == true && ScaleX < 0.2)
		{
			ScaleX += 0.2*Time.deltaTime;
			ScaleZ += 0.2*Time.deltaTime;
		}
		else if (flag == true && ScaleX >= 0.2)
		{
			flag = false;
			ScaleX -= 0.2*Time.deltaTime;
			ScaleZ -= 0.2*Time.deltaTime;
		}
		else if (flag == false && ScaleX > 0.1)
		{
			ScaleX -= 0.2*Time.deltaTime;
			ScaleZ -= 0.2*Time.deltaTime;
		}
		else if (flag == false && ScaleX <= 0.1)
		{
			flag = true;
			ScaleX += 0.2*Time.deltaTime;
			ScaleZ += 0.2*Time.deltaTime;
		}

		Debug.Log(flag+","+ScaleX);
		transform.localScale = new Vector3 ((float)ScaleX, 10, (float)ScaleZ);
		KEYBOARD ();
	}

	void KEYBOARD ()
	{
		if (Input.GetKey (KeyCode.UpArrow))
		{
			transform.Translate (0, Time.deltaTime * 8, 0, Space.World);
			Debug.Log ("W");
		}
 
		if (Input.GetKey (KeyCode.DownArrow))
		{
			transform.Translate (0, -Time.deltaTime * 8, 0, Space.World);
			Debug.Log ("S");
		}
          
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			transform.Translate (-Time.deltaTime * 8, 0, 0, Space.World);
			Debug.Log ("A");
		}
          
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Time.deltaTime * 8, 0, 0, Space.World);
			Debug.Log ("D");
		}

		if (Input.GetKeyDown (KeyCode.F))
		{
			_gm.LostCoinShoot (3);
			UFOtext.text = "emit $-3";
			time = 0.0f;
			Debug.Log ("F");
		}
	}

	void OnTriggerStay (Collider Get)
	{
		if (Get.tag == "UFO" && Input.GetKey (KeyCode.F))
		{
			UFO.status = UFOStatus.Destroy;
			_gm.GetCoinShoot (5);
			UFOtext.text = "hit! $+5";
			time = 0.0f;
		}

	}

	
}
