using UnityEngine;
using System.Collections;

public class Sprite_Animation : MonoBehaviour
{
    //三种动画
    public bool RunTemp;  //奔跑动画
    public bool JumpTemp;  //跳跃动画
    public bool DoubleJumpTemp;  // 双跳动画

    //动画时间
    float TimeTemp;

    // 加载动画
    public Texture[] Run_Image;
    public Texture[] Jump_Image;
    public Texture[] D_Jump_Image;

    int RunAnimationCount; //奔跑次数
    int JumpAnimationCount; // 跳跃次数
    int DoubleJumpAnimationCount; // 第二次跳跃次数


    public float SpeedTemp;



    void Update()
    {

        TimeChange();  // 时间不断改变

        if (JuageTimeTempAndSpeedTemp())
        {
            ResizeTimeTemp();  // 重置时间
            JudgePlayerStatus();  // 判断玩家状态，根据不同状态调用不同函数
        }

    }

    //时间不断变化
    void TimeChange()
    {
        TimeTemp += Time.deltaTime;
    }

    //判断时间和速度的大小
    bool JuageTimeTempAndSpeedTemp()
    {
        if (TimeTemp >= SpeedTemp)  // 若时间大于速度，则返回真
        {
            return true;
        }
        else // 否则，返回假
        {
            return false;
        }
    }

    //重置时间
    void ResizeTimeTemp()
    {
        TimeTemp = 0;
    }

    //判断玩家是否处于奔跑状态
    bool JudgeRunTemp()
    {
        if (RunTemp == true)  // 若为真，返回真
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //判断玩家是否处于跳跃状态
    bool JudgeJumpTemp()
    {
        if (JumpTemp == true) // 若为真，返回真
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //判断玩家是否处于第二次跳跃状态
    bool JudgeDoubleJumpTemp()
    {
        if (DoubleJumpTemp == true) // 若为真，返回真
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //判断玩家状态
    void JudgePlayerStatus()
    {
        if (JudgeRunTemp()) // 若状态为奔跑
        {
            RunningAnimation();  //调用奔跑动画
        }

        if (JudgeJumpTemp()) // 若状态为跳跃
        {

            JumppingAnimation(); //调用跳跃动画
        }

        if (JudgeDoubleJumpTemp()) // 若状态为第二次跳跃
        {

            DoubbleJumppingAnimation(); //调用第二次跳跃动画
        }
    }

    //奔跑数量变化
    void ChangeRunAnimationCount()
    {
        RunAnimationCount++;
    }

    //判断数量是否超出边界
    bool JudgeRunAnimationCount()
    {
        if (RunAnimationCount >= Run_Image.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //初始化RunAnimationCount
    void ResizeRunAnimationCount()
    {
        RunAnimationCount = 0;
    }

    //奔跑动画
    void RunningAnimation()
    {

        ChangeRunAnimationCount();

        if (JudgeRunAnimationCount())
        {
            ResizeRunAnimationCount();
        }

        this.gameObject.GetComponent<Renderer>().material.mainTexture = Run_Image[RunAnimationCount];

    }

    //跳跃数量变化
    void ChangeJumpAnimationCount()
    {
        JumpAnimationCount++;
    }

    //判断数量是否超出边界
    bool JudgeJumpAnimationCount()
    {
        if (JumpAnimationCount >= Jump_Image.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 跳跃动画
    void JumppingAnimation()
    {

        ChangeJumpAnimationCount();

        if (JudgeJumpAnimationCount())
        {
            Run_Play();
            return;
        }
        this.gameObject.GetComponent<Renderer>().material.mainTexture = Jump_Image[JumpAnimationCount];

    }

    //跳跃数量变化
    void ChangeDoubleJumpAnimationCount()
    {
        DoubleJumpAnimationCount++;
    }

    //判断数量是否超出边界
    bool JudgeDoubleJumpAnimationCount()
    {
        if (DoubleJumpAnimationCount >= D_Jump_Image.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 第二次跳跃动画
    void DoubbleJumppingAnimation()
    {

        ChangeDoubleJumpAnimationCount();

        if (JudgeDoubleJumpAnimationCount())
        {
            Run_Play();
            return;
        }
        this.gameObject.GetComponent<Renderer>().material.mainTexture = D_Jump_Image[DoubleJumpAnimationCount];

    }

    //初始化跳跃次数
    void ResizeJumpAnimationCount()
    {
        JumpAnimationCount = 0;
    }

    //初始化第二次跳跃次数
    void ResizeDoubleJumpAnimationCount()
    {
        DoubleJumpAnimationCount = 0;
    }

    //奔跑被调用函数
    public void Run_Play()
    {

        RunTemp = true;
        JumpTemp = false;
        DoubleJumpTemp = false;
        ResizeRunAnimationCount();
    }

    // 第二次跳跃被调用函数	
    public void D_Jump_Play()
    {

        RunTemp = false;
        JumpTemp = false;
        DoubleJumpTemp = true;
        ResizeDoubleJumpAnimationCount();
    }

    //跳跃被调用函数
    public void Jump_Play()
    {

        RunTemp = false;
        JumpTemp = true;
        DoubleJumpTemp = false;
        ResizeJumpAnimationCount();

    }

}

