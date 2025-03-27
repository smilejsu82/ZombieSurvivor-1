using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunData gundata;
    public AudioClip ShootClip;
    public AudioClip ReLoadClip;
    public AudioSource audioSource;
    public float Damage;
    public float MaxAmmos;
    public float CurrMaggerzin;
    public float Delay;
    public float ReLoadTime;
    public ParticleSystem MuzzleFlashEffect;
    public ParticleSystem ShellEjectEffect;
    public bool reloading = false;

    public void Awake()
    {
        Damage = gundata.Damage;
        MaxAmmos = gundata.MaxAmmos;
        CurrMaggerzin = gundata.CurrMaggerzin;
        Delay = gundata.Delay;
        ReLoadTime = gundata.ReLoadTime;

    }

    public void Update()
    {
        if (reloading == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MuzzleFlashEffect.Play();
                ShellEjectEffect.Play();
                audioSource.PlayOneShot(ShootClip);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ReLoad()); 
                audioSource.PlayOneShot(ReLoadClip);
            }
        }
         
        

    }
    public IEnumerator ReLoad()
    {
        reloading = true;
        yield return new WaitForSeconds(ReLoadTime);
        reloading = false;

    }
}
