using UnityEngine;
using System.Collections;

public class Sound_Player : MonoBehaviour
{


    public AudioClip[] Sound; //音效

    void Start()
    {

    }

    public void SoundPlay(int SoundNumber)
    {

        GetComponent<AudioSource>().clip = Sound[SoundNumber]; //播放次数
        GetComponent<AudioSource>().Play(); // 播放音乐

    }

}
