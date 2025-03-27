using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Script/GunData",fileName ="GunDatas")]
public class GunData : ScriptableObject
{
    public float Damage = 25;
    public float MaxAmmos = 100;
    public float CurrMaggerzin = 25;
    public float Delay = 0.13f;
    public float ReLoadTime = 1.8f;
}
