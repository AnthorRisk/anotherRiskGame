using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//飞碟工厂
public class Disk_Factory : MonoBehaviour {
	public GameObject diskPrefab;

	private List<GameObject> used = new List<GameObject>();
	private List<GameObject> free = new List<GameObject>();
	private GameObject bullet;

	void Awake() {
		diskPrefab.SetActive (false);
	}
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {

	}
	/*
	public GameObject getBullet() {
		if (bullet == null)
			Debug.Log ("12");
		bullet.transform.position = new Vector3 (0, 1, -10);
		bullet.SetActive (true);
		bullet.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		return bullet;
	}*/
	public GameObject getDisk() {
		GameObject cy;
		Disk_Data ddata;
		int round = 2;
		int selectColor = 0, color = 0;
		if (free.Count == 0) {
			cy = (GameObject) GameObject.Instantiate(diskPrefab);
			cy.AddComponent<Disk_Data> ();
		} else {
			cy = free [0];
			free.RemoveAt (0);
		}
		ddata = cy.GetComponent<Disk_Data> ();
		//不同的回合产生不同颜色的飞碟。给定了一个概率
		//round 0 只有白色飞碟
		//round 1 白色和黄色飞碟 5:3
		//round 2 白色、黄色和红色飞碟 数量5:3:2
		if (round == 1) {
			selectColor = Random.Range (0, 80);
		} else if (round == 2) {
			selectColor = Random.Range (0, 100);
		} else
			selectColor = 10;

		if (selectColor > 80)
			color = 2;
		else if (selectColor > 50)
			color = 1;
		else
			color = 0;
		color = 2;
		switch (color)
		{
		case 0:
			{
				cy.GetComponent<Renderer> ().material.color = Color.white;
				ddata.color = Color.white;
				ddata.score = 1;
				break;
			}
		case 1:
			{
				cy.GetComponent<Renderer> ().material.color = Color.yellow;
				ddata.color = Color.yellow;
				ddata.score = 3;
				break;
			}
		case 2:
			{
				cy.GetComponent<Renderer> ().material.color = Color.blue;
				Debug.Log (cy.GetComponent<Renderer> ().material.color);	
				ddata.color = Color.red;
				ddata.score = 5;
				break;
			}
		}
		used.Add (cy);
		cy.SetActive (true);
		cy.name = cy.GetInstanceID ().ToString ();
		return cy;
	}
	//释放飞碟资源，加入到free列表中
	public void freeDisk(GameObject cy)
	{
		if (cy != null) {
			used.Remove(cy);
			cy.SetActive (false);
			free.Add (cy);
		}
	}
	public void freeAllDisk()
	{
		int end, index;

		index = 0;
		end = used.Count;

		Debug.Log ("end:");
		Debug.Log (end);
		Debug.Log ("index");
		Debug.Log (index);

		while (index != end)
		{
			Debug.Log ("end:");
			Debug.Log (end);
			Debug.Log ("index");
			Debug.Log (index);
			if (used [index].transform.position.z < -10)
			{
				freeDisk (used [index]);
				end--;
			} else
				index++;
		}
	}

}
