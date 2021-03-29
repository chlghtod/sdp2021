using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("MainScene");
		}
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SoundManager.Instance.PlaySoundEffect(SoundManager.eSound.Test01);
		}
    }
}
