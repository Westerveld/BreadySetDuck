using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    public AudioClip[] duckFeet;

    public AudioClip carHorn;

    public AudioClip duckQuackingGroup;
    public AudioClip[] quack;

    [SerializeField]
    AudioSource sfxSource;

    public void PlaySingleQuack()
    {
        float pitch = Random.value;
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(quack[Random.Range(0, quack.Length)]);
    }

    public void PlayFeet()
    {

    }

    public void PlayHorn()
    {
        float pitch = Random.value;
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(carHorn);
    }
}
