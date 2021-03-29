using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< HEAD:Assets/Scripts/GG171003Scene.cs
public class GG171003Scene : MonoBehaviour
=======
public class 송로민Scene : MonoBehaviour
>>>>>>> 8da7e5a288bfe99604aa45e859fa0e4f5c4e9710:Assets/Scripts/선정안Scene.cs
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
