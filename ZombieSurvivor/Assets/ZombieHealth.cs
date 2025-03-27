using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : LivingEntity
{
    public Slider healthslider;
    public AudioClip deathClip;
    public AudioClip hitClip;
    public AudioSource ZombieAudioSorce;
    //public AudioClip itemPickupClip;

    protected override void OnEnable()
    {
        base.OnEnable();

        healthslider.enabled = true;
        healthslider.maxValue = startingHealth;
        healthslider.value = health;
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
            ZombieAudioSorce.PlayOneShot(hitClip);
        }
        base.OnDamage(damage, hitPoint, hitNormal);
        healthslider.value = health;
    }
    public override void Die()
    {
        base.Die();
        healthslider.gameObject.SetActive(false);

        ZombieAudioSorce.PlayOneShot(deathClip);
    }
}
