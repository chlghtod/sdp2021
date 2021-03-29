using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public enum eSound
    {
        Test01,
        Test02,
        Max,
    }

    private AudioSource audioSourceSE;
    private AudioSource audioSourceBGM;
    private AudioClip[] audioClips = new AudioClip[(int)eSound.Max];
    
    public void Awake() 
    {
        audioSourceSE = gameObject.AddComponent<AudioSource>() as AudioSource;
        audioSourceBGM = gameObject.AddComponent<AudioSource>() as AudioSource;
        audioClips[(int)eSound.Test01] = Resources.Load<AudioClip>("Sounds/test01");
        audioClips[(int)eSound.Test01] = Resources.Load<AudioClip>("Sounds/test02");
    }

    public void PlaySoundEffect(eSound index)
    {
        Debug.Log("PlaySoundEffect : "+index);
        audioSourceSE.PlayOneShot(audioClips[(int)index]);
    }

    public void PlayBackgroundMusic()
    {
        // audioSourceBGM.clip = audioClips[(int)eSound.BackgroundMusic1];
        // audioSourceBGM.loop = true;
        // audioSourceBGM.Play();
    }

    public void StopBackgroundMusic()
    {
        audioSourceBGM.Stop();
    }
}
