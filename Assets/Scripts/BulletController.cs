using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime;

    private void Start()
    {
        
    }

    private void Update()
    {
        bulletLifeTime -= Time.deltaTime;

        if (bulletLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }
}
