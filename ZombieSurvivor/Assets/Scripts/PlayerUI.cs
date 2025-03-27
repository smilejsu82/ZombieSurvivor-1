using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public PlayerControll playerControll;
    public Gun gun;
    public TMP_Text AmmoText;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = $"maxAmmo : {gun.MaxAmmos}\n{gun.CurrMaggerzin}/{gun.maggerzin}";
    }
}
