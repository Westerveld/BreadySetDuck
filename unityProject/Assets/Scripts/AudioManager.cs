using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    public AudioClip duckFeet;
    public AudioClip duckFootSlap;

    public AudioClip carHorn;

    public AudioClip duckQuackingGroup;
    public AudioClip[] quack;

    public AudioClip burnClip;

    [SerializeField]
    AudioSource sfxSource;

    private void Awake()
    {
        if(_instance ==null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySingleQuack()
    {
        /*float pitch = Random.value;
        sfxSource.pitch = pitch;*/
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(quack[Random.Range(0, quack.Length)]);
    }

    public void PlayFeet()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(duckFeet);
    }

    public void PlayFoot()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(duckFootSlap);
    }

    public void PlayHorn()
    {
        /*float pitch = Random.value;
        sfxSource.pitch = pitch;*/
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(carHorn);
    }

    public void PlayBurn()
    {
        //sfxSource.pitch = Random.value;
        sfxSource.PlayOneShot(burnClip);
    }
}
