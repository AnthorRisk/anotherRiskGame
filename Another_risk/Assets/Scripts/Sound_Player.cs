using UnityEngine;
using System.Collections;

public class Sound_Player : MonoBehaviour
{


    public AudioClip[] Sound; //��Ч

    void Start()
    {

    }

    public void SoundPlay(int SoundNumber)
    {

        GetComponent<AudioSource>().clip = Sound[SoundNumber]; //���Ŵ���
        GetComponent<AudioSource>().Play(); // ��������

    }

}
