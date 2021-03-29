using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LJH_Scene : MonoBehaviour
{
    [SerializeField] private Text sceneName_text;

    private void Start()
    {
        sceneName_text.text = $"Scene Name : {SceneManager.GetActiveScene().name}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.PlaySoundEffect(SoundManager.eSound.Test02);
        }
    }
}
