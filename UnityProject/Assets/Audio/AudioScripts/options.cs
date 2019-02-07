using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class options : MonoBehaviour
{
    public AudioMixer masterMixer;
    
    // Start is called before the first frame update

    public void SetMusicVol(float musicVol)
    {
        masterMixer.SetFloat("musicVol", musicVol);//set vol in a parameter
    }
    public void SetSfxVol(float sfxVol)
    {
        masterMixer.SetFloat("sfxVol", sfxVol);//set vol in a parameter
    }
}
