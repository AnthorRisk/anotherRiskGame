using UnityEngine;
using System.Collections;

public class Camera_Zoom : MonoBehaviour
{

	public Camera _camera;
	public GameObject _player;

	public float MaxSize;
	public float MinSize;

	float CameraSize = 10f;
	float speed = 0.45f;
	
	void Start()
	{
	
		_player = GameObject.Find("03_Player");
	}
	
	
	void Update ()
	{
		//根据玩家的y坐标的位置改变摄像机的正交大小
		if (_player != null)
		{
			CameraSize = 5.5f + _player.transform.position.y;
		}
			
		OverSize();

		//当玩家跳起的时候，镜头拉远，当玩家向前跑的时候镜头拉近，画面更有层次感
		_camera.orthographicSize = Mathf.Lerp (_camera.orthographicSize, CameraSize, Time.deltaTime / speed);
		
	}

	void OverSize ()
	{
		//控制摄像机正交大小的范围
		if (CameraSize <= MinSize)
		{
			CameraSize = MinSize;
		}

		if (CameraSize >= MaxSize)
		{
			CameraSize = MaxSize;
		}
	}
}
