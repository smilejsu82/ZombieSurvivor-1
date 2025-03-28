using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    public Slider healthslider;
    public AudioClip deathClip;
    public AudioClip hitClip;
    //public AudioClip itemPickupClip;
    public GameObject gameOver;

    public AudioSource playeraudiosource;
    public Animator playeranimator;
    public PlayerControll playerControll;
    public Gun playershooter;

    protected override void OnEnable()
    {
        base.OnEnable();

        healthslider.enabled = true;
        healthslider.maxValue = startingHealth;
        healthslider.value = health;
        playeranimator.enabled = true;
        playerControll.enabled = true;
        playershooter.enabled = true;
        gameOver.SetActive(false);
    }

    public override void RestoreHealth(float newHealth)
    {
        base.RestoreHealth(newHealth);
        healthslider.value = health;
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        
        if (!dead)
        {
            playeraudiosource.PlayOneShot(hitClip);
        }
        base.OnDamage(damage, hitPoint, hitNormal);
        healthslider.value = health;
    }
    public override void Die()
    {
        base.Die();
        healthslider.gameObject.SetActive(false);

        playeraudiosource.PlayOneShot(deathClip);
        playeranimator.SetTrigger("IsDie");
        playerControll.enabled = false;
        playershooter.enabled = false;
        gameOver.SetActive(true);
    }
}
