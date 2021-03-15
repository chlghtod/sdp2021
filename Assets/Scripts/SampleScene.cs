using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlaySoundEffect(SoundManager.eSound.Test01);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
