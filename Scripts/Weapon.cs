using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float Damage;


    public bool IsRange;

    public float Range;
    public float AttackRate;
    public Transform FirePoint;
    public GameObject BulletPrefab;

    public Weapon(float damage, bool is_range, float attack_rate)
    {
        Damage = damage;
        IsRange = is_range;
        AttackRate = attack_rate;
    }



}
