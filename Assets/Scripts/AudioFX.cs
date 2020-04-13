using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{

    public AudioClip[] fxs;
    AudioSource audioS;

    public void FXSonidoChoque()
    {
        audioS.clip = fxs[0];
        audioS.Play();
    }

    public void FXMusic()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
