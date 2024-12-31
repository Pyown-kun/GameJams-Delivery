using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Material SlashMaterial;

    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private float flashDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Material defaultMaterial;

    private void Start()
    {
        health = maxHealth;
        defaultMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(ChangeMaterial());
    }

    private IEnumerator ChangeMaterial()
    {
        spriteRenderer.material = SlashMaterial;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.material = defaultMaterial;
    }
}
