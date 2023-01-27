using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoundManager : MonoBehaviour
{
    AudioSource sound;
    public AudioClip soundClip;

    public static CSoundManager soundManager;

    private void Awake()
    {
        if (CSoundManager.soundManager == null)
        {
            CSoundManager.soundManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        sound.PlayOneShot(soundClip);
    }
}
