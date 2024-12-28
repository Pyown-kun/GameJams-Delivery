using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionScripts : MonoBehaviour
{
    public int AmmoAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerShoot playerShoot = collision.GetComponent<PlayerShoot>();
            playerShoot.BulletAdd(AmmoAmount);
            Destroy(gameObject);
        }
    }
}
