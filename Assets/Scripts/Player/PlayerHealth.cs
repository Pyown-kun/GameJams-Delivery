using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Pause Pause;

    [SerializeField] private Material SlashMaterial;

    [SerializeField] private int maxHealth;
    [SerializeField] private int health; 
    [SerializeField] private float flashDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Material defaultMaterial;

    public Text healthText;

    private void Start()
    {
        health = maxHealth;
        defaultMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        healthText.text = "X " + health;

        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!Pause.IsPause)
        {
            health -= damage;
            StartCoroutine(ChangeMaterial());
        }
    }
    private IEnumerator ChangeMaterial()
    {
        spriteRenderer.material = SlashMaterial;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.material = defaultMaterial;
    }
}
