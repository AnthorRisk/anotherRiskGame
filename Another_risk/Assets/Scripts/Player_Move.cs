using UnityEngine;
using System.Collections;

//通过枚举列出player运动的状态
public enum PlayerMoveStatus
{
    // 动作分为奔跑，跳跃，第二次跳跃，死亡
    Run,
    Jump,
    DoubleJump,
    Die
};

public class Player_Move : MonoBehaviour
{
    public Sprite_Animation _SA;  // 动画
    public Sound_Player _SP;  // 声音
    public float Jump_Power;  //跳跃能量
    public PlayerMoveStatus status;  // player状态

    void Start()
    {

    }

    //每一帧不断检测从键盘和鼠标的输入
    void Update()
    {
        KEYBOARD(); //检测键盘
        TOUCH();
        GetComponent<Rigidbody>().WakeUp();
    }

    //设置玩家的状态为run
    void SetRunstatus()
    {
        status = PlayerMoveStatus.Run;
    }

    //判断动画是否为空
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

    //判断音乐是否为空
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

    //奔跑动画
    void RUN()
    {
 
        SetRunstatus();

        //奔跑动画
        if (JudgeSprite_Animation())
        {
            _SA.Run_Play();
        }
    }

    //设置玩家的状态为Jump
    void SetJumpstatus()
    {
        status = PlayerMoveStatus.Jump;
    }

    //播放音乐
    void PlayMusic()
    {
        // 若音乐不为空，则执行播放音乐
        if (JudgeSound_Player())
        {
            _SP.SoundPlay(0);
        }
    }

    //跳跃
    void JUMP()
    {

        ////status = PlayerMoveStatus.Jump;
        SetJumpstatus();

        //通过给对象一个向上的力来完成向上跳的动作
        GetComponent<Rigidbody>().AddForce(0, Jump_Power * 1.5f, 0);//向上跳

        // 若动画不为空，则执行动画
        if (JudgeSprite_Animation())
        {
            _SA.Jump_Play();
        }

        //播放音乐
        PlayMusic();

    }

    //设置玩家的状态为Jump
    void SetDoubleJump()
    {
        status = PlayerMoveStatus.DoubleJump;
    }

    // 跳跃两次
    void DOUBLEJUMP()
    {

        //设置状态为双跳
        SetDoubleJump();

        // 给对象一个向上的力
        GetComponent<Rigidbody>().AddForce(0, Jump_Power, 0);

        // 若动画不为空，则执行动画
        if (JudgeSprite_Animation())
        {
            _SA.D_Jump_Play();
        }

        //播放音乐
        PlayMusic();
    }

    //若当前状态是jump，则下一状态执行双跳
    void playerjumpstatus()
    {
        if (status == PlayerMoveStatus.Jump)
        {
            DOUBLEJUMP();
        }
    }

    //若当前状态是奔跑，则下一状态设置为跳跃
    void playerrunstatus()
    {
        if (status == PlayerMoveStatus.Run)
        {
            JUMP();
        }
    }

    //检测player状态是否为死亡
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

    //若player的状态不是死亡，则一直run
    void OnCollisionEnter(Collision Get)
    {
        if (JudgePlayeDieStatus())
        {
            RUN();
        }
    }

    // 通过键盘输入来控制动画
    void KEYBOARD()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerjumpstatus(); //跳跃检测状态
            playerrunstatus();  // 奔跑检测状态
        }
    }

    //判断输入
    void TOUCH()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                playerjumpstatus(); //跳跃检测状态
                playerrunstatus();  // 奔跑检测状态
            }


        }
    }


}
