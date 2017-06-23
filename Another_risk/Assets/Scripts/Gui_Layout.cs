using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Gui_Layout : MonoBehaviour // ����
{
    // ö��λ��
    public enum positionType
	{
		TopLeft,
		TopMiddle,
		TopRight,
		MiddleLeft,
		Middle,
		MiddleRight,
		BottomLeft,
		BottomMiddle,
		BottomRight
	}

    public positionType _positionType = positionType.Middle;
    public float margin_x, margin_y;  // ����
    public int _depth;  // ���
    float screenX, screenY;  //��Ļ
    GUIText _gui_text;  // �ı�
    GUITexture _gui_texture;  // �ı�
    float _guiWidth, _guiHeight;

    bool TextureIN = false;

    //������Ļ
    void SetScreen()
    {
        screenX = Screen.width;
        screenY = Screen.height;
    }

    void Awake ()
	{
		//��unity ƽ̨
        #if !(UNITY_EDITOR)
		
		_gui_text = GetComponent<GUIText> ();
		_gui_texture = GetComponent<GUITexture> ();
        SetScreen();
		
		
		
		if (_gui_texture != null) {
			_guiWidth = _gui_texture.pixelInset.width;
			_guiHeight = _gui_texture.pixelInset.height;
		}

		PositionSetting ();
        #endif


    }

    //����gui�Ŀ�Ⱥͳ���
    void SetGui()
    {
        _guiWidth = _gui_texture.pixelInset.width;
        _guiHeight = _gui_texture.pixelInset.height;
    }

    //�жϺ���
    bool Judge()
    {
        if (_gui_texture.texture != null && TextureIN == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update ()
	{ 
		//�������Ϸ�������Unity�༭���ű�

		#if UNITY_EDITOR
		
		_gui_text = GetComponent<GUIText> ();
		_gui_texture = GetComponent<GUITexture> ();
        SetScreen();

        if (_gui_texture != null)
		{

            SetGui();

            if (Judge())
            {
				TextureIN =true;
				_guiWidth = _gui_texture.texture.width;
				_guiHeight = _gui_texture.texture.height;
				TextureIN =false;
			}
			
		}
		
		this.gameObject.transform.position = new Vector3 (0, 0, -0.01f * _depth);
		PositionSetting ();
		
		#endif
	}

    // �ж��ı��Ƿ�Ϊ��
    bool Judge_gui_text()
    {
        if (_gui_text != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�ж��ı��Ƿ�Ϊ��
    bool Judge_gui_texture()
    {
        if (_gui_texture != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void PositionSetting ()
	{
		//����õ��ı���
		float s_m_Y = screenY - margin_y;
		float s_m_X = screenX - margin_x;
		float s_gh_m_Y = screenY - _guiHeight - margin_y;
		float s5_mx_gw5 = screenX * 0.5f + margin_x - _guiWidth * 0.5f;
		float s5_gh5_m_Y = screenY * 0.5f - _guiHeight * 0.5f + margin_y;
		float s5_m_Y = screenY * 0.5f + margin_y;
		float s5_m_X = screenX * 0.5f + margin_x;

		switch (_positionType)
		{

		case positionType.TopLeft:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (margin_x, s_m_Y);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (margin_x, s_gh_m_Y,_guiWidth, _guiHeight);
			}

			break;

		case positionType.TopMiddle:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (screenX * 0.5f - margin_x, s_m_Y);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (s5_mx_gw5, s_gh_m_Y, _guiWidth, _guiHeight);
			}

			break;

		case positionType.TopRight:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (s_m_X, s_m_Y);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (s_m_X - _guiWidth, s_gh_m_Y, _guiWidth, _guiHeight);
			}

			break;

		case positionType.MiddleLeft:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (margin_x, screenY * 0.5f);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (margin_x, s5_gh5_m_Y, _guiWidth, _guiHeight);
			}

			break;

		case positionType.Middle:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (s5_m_X, s5_m_Y);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (screenX * 0.5f - _guiWidth * 0.5f + margin_x, s5_gh5_m_Y, _guiWidth, _guiHeight);
			}

			break;

		case positionType.MiddleRight:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (s_m_X, s5_m_Y);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (s_m_X - _guiWidth, s5_gh5_m_Y, _guiWidth, _guiHeight);
			}

			break;

		case positionType.BottomLeft:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (margin_x, margin_y);
			}

			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (margin_x, margin_y, _guiWidth, _guiHeight);
			}

			break;

		case positionType.BottomMiddle:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (s5_m_X, margin_y);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (s5_mx_gw5, margin_y, _guiWidth, _guiHeight);
			}

			break;

		case positionType.BottomRight:

			if (Judge_gui_text())
			{
				_gui_text.pixelOffset = new Vector2 (s_m_X, margin_y);
			}
			if (Judge_gui_texture())
			{
				_gui_texture.pixelInset = new Rect (s_m_X - _guiWidth, margin_y, _guiWidth, _guiHeight);
			}

			break;
		}
	}
}