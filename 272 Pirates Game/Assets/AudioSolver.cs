using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSolver : MonoBehaviour
{
    public AudioClip defaultAmbience;

    public AudioSource track01; //track02;
    //private bool isPlayignTrack01;

    public static AudioSolver instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //track02 = gameObject.AddComponent<AudioSource>();
        //isPlayignTrack01 = true;

        SwapTrack(defaultAmbience);
    }

    /*public void SwapTrack(AudioClip newClip)
    {
        if(isPlayignTrack01)
        {
            track02.clip = newClip;
            track02.Play();
            track01.Stop();
        }
        else
        {
            track01.clip = newClip;
            track01.Play();
            track02.Stop();
        }

        isPlayignTrack01 = !isPlayignTrack01;
    }*/

    public void SwapTrack(AudioClip newClip)
    {
        track01.Stop();
        track01.clip = newClip;
        track01.Play();
    }

}
