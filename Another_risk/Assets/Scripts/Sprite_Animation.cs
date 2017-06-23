using UnityEngine;
using System.Collections;

public class Sprite_Animation : MonoBehaviour
{
    //���ֶ���
    public bool RunTemp;  //���ܶ���
    public bool JumpTemp;  //��Ծ����
    public bool DoubleJumpTemp;  // ˫������

    //����ʱ��
    float TimeTemp;

    // ���ض���
    public Texture[] Run_Image;
    public Texture[] Jump_Image;
    public Texture[] D_Jump_Image;

    int RunAnimationCount; //���ܴ���
    int JumpAnimationCount; // ��Ծ����
    int DoubleJumpAnimationCount; // �ڶ�����Ծ����


    public float SpeedTemp;



    void Update()
    {

        TimeChange();  // ʱ�䲻�ϸı�

        if (JuageTimeTempAndSpeedTemp())
        {
            ResizeTimeTemp();  // ����ʱ��
            JudgePlayerStatus();  // �ж����״̬�����ݲ�ͬ״̬���ò�ͬ����
        }

    }

    //ʱ�䲻�ϱ仯
    void TimeChange()
    {
        TimeTemp += Time.deltaTime;
    }

    //�ж�ʱ����ٶȵĴ�С
    bool JuageTimeTempAndSpeedTemp()
    {
        if (TimeTemp >= SpeedTemp)  // ��ʱ������ٶȣ��򷵻���
        {
            return true;
        }
        else // ���򣬷��ؼ�
        {
            return false;
        }
    }

    //����ʱ��
    void ResizeTimeTemp()
    {
        TimeTemp = 0;
    }

    //�ж�����Ƿ��ڱ���״̬
    bool JudgeRunTemp()
    {
        if (RunTemp == true)  // ��Ϊ�棬������
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�ж�����Ƿ�����Ծ״̬
    bool JudgeJumpTemp()
    {
        if (JumpTemp == true) // ��Ϊ�棬������
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�ж�����Ƿ��ڵڶ�����Ծ״̬
    bool JudgeDoubleJumpTemp()
    {
        if (DoubleJumpTemp == true) // ��Ϊ�棬������
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //�ж����״̬
    void JudgePlayerStatus()
    {
        if (JudgeRunTemp()) // ��״̬Ϊ����
        {
            RunningAnimation();  //���ñ��ܶ���
        }

        if (JudgeJumpTemp()) // ��״̬Ϊ��Ծ
        {

            JumppingAnimation(); //������Ծ����
        }

        if (JudgeDoubleJumpTemp()) // ��״̬Ϊ�ڶ�����Ծ
        {

            DoubbleJumppingAnimation(); //���õڶ�����Ծ����
        }
    }

    //���������仯
    void ChangeRunAnimationCount()
    {
        RunAnimationCount++;
    }

    //�ж������Ƿ񳬳��߽�
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

    //��ʼ��RunAnimationCount
    void ResizeRunAnimationCount()
    {
        RunAnimationCount = 0;
    }

    //���ܶ���
    void RunningAnimation()
    {

        ChangeRunAnimationCount();

        if (JudgeRunAnimationCount())
        {
            ResizeRunAnimationCount();
        }

        this.gameObject.GetComponent<Renderer>().material.mainTexture = Run_Image[RunAnimationCount];

    }

    //��Ծ�����仯
    void ChangeJumpAnimationCount()
    {
        JumpAnimationCount++;
    }

    //�ж������Ƿ񳬳��߽�
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

    // ��Ծ����
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

    //��Ծ�����仯
    void ChangeDoubleJumpAnimationCount()
    {
        DoubleJumpAnimationCount++;
    }

    //�ж������Ƿ񳬳��߽�
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

    // �ڶ�����Ծ����
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

    //��ʼ����Ծ����
    void ResizeJumpAnimationCount()
    {
        JumpAnimationCount = 0;
    }

    //��ʼ���ڶ�����Ծ����
    void ResizeDoubleJumpAnimationCount()
    {
        DoubleJumpAnimationCount = 0;
    }

    //���ܱ����ú���
    public void Run_Play()
    {

        RunTemp = true;
        JumpTemp = false;
        DoubleJumpTemp = false;
        ResizeRunAnimationCount();
    }

    // �ڶ�����Ծ�����ú���	
    public void D_Jump_Play()
    {

        RunTemp = false;
        JumpTemp = false;
        DoubleJumpTemp = true;
        ResizeDoubleJumpAnimationCount();
    }

    //��Ծ�����ú���
    public void Jump_Play()
    {

        RunTemp = false;
        JumpTemp = true;
        DoubleJumpTemp = false;
        ResizeJumpAnimationCount();

    }

}

