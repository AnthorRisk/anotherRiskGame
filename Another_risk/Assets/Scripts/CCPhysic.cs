using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//管理飞碟具体动作的类
public class CCPhysic : SSActionManager, ISSActionCallback {
	public Game_Manager _gm;
	//如果飞碟动作完成，释放飞碟资源
	public void SSActionEvent(SSAction ac)
	{
		if (ac is CCFlyDisk)
		{
			GameObject a = GameObject.Find("05_GameManager");

			if(a!=null)
			{
				_gm = a.GetComponent<Game_Manager>();
			}

			Disk_Factory factory = _gm.DF;
			factory.freeDisk (ac.gameobject);
		}
	}

	public void StartGame(GameObject cy)
	{
		cy.SetActive (true);
		cy.transform.position = new Vector3 (Random.Range (-2f, 5f), Random.Range (7f, 10f), 0);

		RunAction (cy, CCFlyDisk.getSSAction(), this);
		RunAction (cy, CCFlyDisk.getSSAction(), this);
	}
	/*
	 *可增加的设计功能
	public void shoot(Vector3 dir) {
		Disk_Factory factory = _gm.DF;
		GameObject bullet = factory.getBullet ();
		bullet.GetComponent<Rigidbody> ().velocity = 100*(dir-new Vector3(0, 1, -10));
		bullet.GetComponent<Rigidbody> ().useGravity = false;
	}*/
}   
