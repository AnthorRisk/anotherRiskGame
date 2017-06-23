using UnityEngine;
using System.Collections;

//ͨ��ö���г�player�˶���״̬
public enum PlayerMoveStatus
{
    // ������Ϊ���ܣ���Ծ���ڶ�����Ծ������
    Run,
    Jump,
    DoubleJump,
    Die
};

public class Player_Move : MonoBehaviour
{
    public Sprite_Animation _SA;  // ����
    public Sound_Player _SP;  // ����
    public float Jump_Power;  //��Ծ����
    public PlayerMoveStatus status;  // player״̬

    void Start()
    {

    }

    //ÿһ֡���ϼ��Ӽ��̺���������
    void Update()
    {
        KEYBOARD(); //������
        TOUCH();
        GetComponent<Rigidbody>().WakeUp();
    }

    //������ҵ�״̬Ϊrun
    void SetRunstatus()
    {
        status = PlayerMoveStatus.Run;
    }

    //�ж϶����Ƿ�Ϊ��
    bool JudgeSprite_Animation()
    {
        if (_SA != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�ж������Ƿ�Ϊ��
    bool JudgeSound_Player()
    {
        if (_SP != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //���ܶ���
    void RUN()
    {
 
        SetRunstatus();

        //���ܶ���
        if (JudgeSprite_Animation())
        {
            _SA.Run_Play();
        }
    }

    //������ҵ�״̬ΪJump
    void SetJumpstatus()
    {
        status = PlayerMoveStatus.Jump;
    }

    //��������
    void PlayMusic()
    {
        // �����ֲ�Ϊ�գ���ִ�в�������
        if (JudgeSound_Player())
        {
            _SP.SoundPlay(0);
        }
    }

    //��Ծ
    void JUMP()
    {

        ////status = PlayerMoveStatus.Jump;
        SetJumpstatus();

        //ͨ��������һ�����ϵ���������������Ķ���
        GetComponent<Rigidbody>().AddForce(0, Jump_Power * 1.5f, 0);//������

        // ��������Ϊ�գ���ִ�ж���
        if (JudgeSprite_Animation())
        {
            _SA.Jump_Play();
        }

        //��������
        PlayMusic();

    }

    //������ҵ�״̬ΪJump
    void SetDoubleJump()
    {
        status = PlayerMoveStatus.DoubleJump;
    }

    // ��Ծ����
    void DOUBLEJUMP()
    {

        //����״̬Ϊ˫��
        SetDoubleJump();

        // ������һ�����ϵ���
        GetComponent<Rigidbody>().AddForce(0, Jump_Power, 0);

        // ��������Ϊ�գ���ִ�ж���
        if (JudgeSprite_Animation())
        {
            _SA.D_Jump_Play();
        }

        //��������
        PlayMusic();
    }

    //����ǰ״̬��jump������һ״ִ̬��˫��
    void playerjumpstatus()
    {
        if (status == PlayerMoveStatus.Jump)
        {
            DOUBLEJUMP();
        }
    }

    //����ǰ״̬�Ǳ��ܣ�����һ״̬����Ϊ��Ծ
    void playerrunstatus()
    {
        if (status == PlayerMoveStatus.Run)
        {
            JUMP();
        }
    }

    //���player״̬�Ƿ�Ϊ����
    bool JudgePlayeDieStatus()
    {
        if (status != PlayerMoveStatus.Die)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //��player��״̬������������һֱrun
    void OnCollisionEnter(Collision Get)
    {
        if (JudgePlayeDieStatus())
        {
            RUN();
        }
    }

    // ͨ���������������ƶ���
    void KEYBOARD()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerjumpstatus(); //��Ծ���״̬
            playerrunstatus();  // ���ܼ��״̬
        }
    }

    //�ж�����
    void TOUCH()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                playerjumpstatus(); //��Ծ���״̬
                playerrunstatus();  // ���ܼ��״̬
            }


        }
    }


}
