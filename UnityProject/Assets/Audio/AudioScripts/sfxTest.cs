using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class sfxTest : MonoBehaviour
{
    AudioSource source;
    public AudioClip test;

    void Start()
    {

        source = GetComponent<AudioSource>();
        test = GetComponent<AudioClip>();
        
    }

    // Start is called before the first frame update
    public void testSfX()
    {
        source.Play(0);
    }
}
