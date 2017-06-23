using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//管理飞碟具体动作的类
public class CCActionManager : SSActionManager, ISSActionCallback {
	
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
		RunAction (cy, CCFlyDisk.getSSAction(), this);
	}
}
 