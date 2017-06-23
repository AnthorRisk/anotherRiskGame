using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//实现飞碟的动作
public class CCFlyDisk : SSAction {
	private float acc;
	private Vector3 force;

	private float time;
	// Use this for initialization
	public override void Start ()
	{
		enable = true;

		this.gameobject.transform.position = new Vector3 (Random.Range (-2f, 5f), Random.Range (7f, 10f), 0);
		this.gameobject.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range (-3f, 3f), Random.Range (-1f, -3f), 0);
		this.gameobject.GetComponent<Rigidbody> ().AddForce (new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (2.0f, 5.0f), 0));
	}
	
	// Update is called once per frame
	public override void Update ()
	{
	}

	public static CCFlyDisk getSSAction()
	{
		CCFlyDisk ac = ScriptableObject.CreateInstance<CCFlyDisk> ();
		return ac;
	}
}
