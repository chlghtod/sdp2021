using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MWLeeScene : MonoBehaviour
{
    #region 변수

    #endregion


    #region 함수

    #endregion


    #region 실행

    private void Update()
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

    #endregion
}
