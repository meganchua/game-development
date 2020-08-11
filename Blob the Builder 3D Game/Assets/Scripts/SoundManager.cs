using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip blobSound, deathSound, gameSound, jumpSound, overSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        blobSound = Resources.Load<AudioClip>("BlobTheBuilder");
        deathSound = Resources.Load<AudioClip>("death");
        gameSound = Resources.Load<AudioClip>("gameplay");
        jumpSound = Resources.Load<AudioClip>("jump");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void sound(string clip)
    {
        switch (clip)
        {
            case "blob":
                audioSrc.PlayOneShot(blobSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "game":
                audioSrc.PlayOneShot(gameSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
        }
    }
}
