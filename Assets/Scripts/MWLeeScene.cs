using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MWLeeScene : MonoBehaviour
{
    #region ����

    #endregion


    #region �Լ�

    #endregion


    #region ����

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
