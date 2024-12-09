using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Type_Gun
{
    Assault_Rifles,
    DMRs,
    Pistols,
    Shotguns,
    SMG,
    Sniper_Rifles
};

public enum Rarity_Tiers
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    MyThic
}

[CreateAssetMenu(fileName = "Assets/Data/Gun", menuName = "ItemSO/Weapons")]
public class GunSO : ScriptableObject
{
    [Header("UI")]
    public Type_Gun Type_Gun;
    public Rarity_Tiers Rarity_Tiers;
    [Range(0, 100)] public float Charge_Rate;
    [Range(0, 100)] public float Impact;
    [Range(0, 100)] public float Range;
    [Range(0, 100)] public float Stability;
    [Range(0, 100)] public float Reload;
    public int Buttlet_Quantity;
    public int Comsuming_Attack;
    public string Name_Gun;
    public Texture2D Texture2D;
    [TextArea(2, 300)]
    public string Description;
    public float Price;

    /*[Header("PHYSICS")]
    public GameObject Model;
    public Vector3 ButtetSpreedVariance;
    public float ShootDelay;
    public float BulletSpeed;
    public Vector3 BulletDiection;
    public LayerMask Ground;
    public LayerMask Enemy;

    [Header("VFX")]
    public ParticleSystem Splash;
    public ParticleSystem ImpactBlood;
    public ParticleSystem ImpactNormal;
    public TrailRenderer Bullettrail;*/
}
