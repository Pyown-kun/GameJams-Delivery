using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    [SerializeField] private float timeBeforeExplode;

    private void Update()
    {
        timeBeforeExplode -= Time.deltaTime;

        if (timeBeforeExplode <= 0)
        {
            Destroy(gameObject);
        }
    }
}
