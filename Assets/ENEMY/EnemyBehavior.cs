using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Enemybehavior : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 3;
    public GameObject explosion;

    private void Start()
    {
        Hitpoints = MaxHitpoints;
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion);
            
        }
    }
}
