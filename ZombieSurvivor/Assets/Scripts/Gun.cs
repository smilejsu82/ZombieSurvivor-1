using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class Gun : MonoBehaviour
{
    public GunData gundata;
    public string GunName;
    public AudioClip ShootClip;
    public AudioClip ReLoadClip;
    public AudioSource audioSource;
    public float Damage;
    public float MaxAmmos;
    public float CurrMaggerzin;
    public float maggerzin;
    public float Delay;
    public float ReLoadTime;
    public ParticleSystem MuzzleFlashEffect;
    public ParticleSystem ShellEjectEffect;
    public bool reloading = false;
    public Transform Firepos;
    public LineRenderer lineRenderer;
    public List<GameObject> enemys;
    public GameObject Player;
    public float LastShootTime;
    public LivingEntity livingEntity;


    public void Awake()
    {
        Damage = gundata.Damage;
        MaxAmmos = gundata.MaxAmmos;
        CurrMaggerzin = gundata.CurrMaggerzin;
        maggerzin = CurrMaggerzin;
        Delay = gundata.Delay;
        ReLoadTime = gundata.ReLoadTime;

    }

    public void Update()
    {
        if (reloading == false)
        {
            if (Time.time >= LastShootTime + Delay&& CurrMaggerzin !=0)
            {
                
                if (Input.GetMouseButtonDown(0))
                {
                    LastShootTime = Time.time;
                    StartCoroutine(Shoot());
                } 
            }
               
            
            if (Input.GetKeyDown(KeyCode.R)&&MaxAmmos >0 &&CurrMaggerzin!=maggerzin)
            {
                StartCoroutine(ReLoad()); 
                audioSource.PlayOneShot(ReLoadClip);
            }
        }
         
        

    }
    public IEnumerator ReLoad()
    {
        reloading = true;
        if (MaxAmmos <= maggerzin)
        {
            if (maggerzin <= CurrMaggerzin + MaxAmmos)
            {
                MaxAmmos += CurrMaggerzin;
                MaxAmmos -= maggerzin;
                CurrMaggerzin = maggerzin;
            }
            
            MaxAmmos = 0;
        }
        else
        {
            MaxAmmos = MaxAmmos + CurrMaggerzin;
            MaxAmmos -= maggerzin;
            CurrMaggerzin = maggerzin;
        }
            yield return new WaitForSeconds(ReLoadTime);
        reloading = false;

    }
    //public IEnumerator Shoot()
    //{
    //    
    //    audioSource.PlayOneShot(ShootClip);
    //    RaycastHit hit;
    //    Vector3 hitpos = Vector3.zero;

    //    if (Physics.Raycast(Firepos.position, Firepos.forward, out hit, 20f) 
    //    { 
    //        IDamageaBle Target
    //    }
    //    //사격 딜레이 만큼 기다리게 시킴
    //    yield return new WaitForSeconds(Delay);
    //}
    private IEnumerator Shoot()
    {
        RaycastHit hit;

        Vector3 endpos = Firepos.position + Firepos.forward * 20f;
        var dir = endpos - Firepos.position;
        if (Physics.Raycast(Firepos.position, dir.normalized, out hit, 20f))
        {
            MuzzleFlashEffect.Play();
            ShellEjectEffect.Play();
            CurrMaggerzin--;

            Debug.Log($"<color=yellow>{hit.collider.gameObject.name}</color>");

            IDamageable target = hit.collider.GetComponent<IDamageable>();

            Zombie zombie = target as Zombie;

            Debug.Log($"<color=lime>zombie: {zombie}</color>");

            if (zombie != null)
            {
                Debug.Log($"목표물에 부딫혔습니다 {hit.transform.position}");
                zombie.OnDamage(Damage, hit.point, hit.normal);
            }
           
            transform.LookAt(hit.transform);
            endpos = hit.point;
        }
        lineRenderer.SetPositions(new Vector3[] { Firepos.position, endpos });

        lineRenderer.enabled = true;
        yield return new WaitForSeconds(Delay);

        lineRenderer.enabled = false;
        yield return null;
        
    }
    
    }
