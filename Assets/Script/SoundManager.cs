using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioNames
{ 
    pop_1,
    pop_2,
    BGM1
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioClip pop_1;
    public AudioClip pop_2;
    public AudioClip BGM1;
    private AudioSource mAudioSource;
    //I'll need a list for later development

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupSoundManager()
    {
        //if (soundManager != null)
        //{
        //    soundManager = null;
        //}
        soundManager = this;

        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.clip = BGM1;
        mAudioSource.Play();
        mAudioSource.loop = true;
        //Debug.Log(pop_1.name);
    }

    public void PlayAudio(string audioName)
    {
        //for a longer list just how do I manage? Don't know how

        //Concept: I'll make a list containing name string and audioclip
        if (audioName == pop_1.name)
        {
            Debug.Log("POP1");
            mAudioSource.PlayOneShot(pop_1);
        }
        if (audioName == pop_2.name)
        {
            Debug.Log("POP1");
            mAudioSource.PlayOneShot(pop_2);
        }
    }
}
