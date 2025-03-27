using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Slider PlayerSlider;
    public AudioClip DeathSound;
    public AudioClip HealthSound;
    public AudioClip HitSound;
    private AudioSource PlayeraudioSource;
    public PlayerControll playerControll;
    public PlayerAnimator playerAnimator;
    public Gun gun;
    public TMP_Text AmmoText;

    void Start()
    {
        PlayeraudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSlider.value <= 0 && PlayeraudioSource.enabled == true)
        {
            PlayeraudioSource.PlayOneShot(DeathSound);
             new WaitForSeconds(6f);
            
            PlayeraudioSource.enabled = false;
        }
        AmmoText.text = $"maxAmmo : {gun.MaxAmmos}\n{gun.CurrMaggerzin}/{gun.maggerzin}";
    }
}
