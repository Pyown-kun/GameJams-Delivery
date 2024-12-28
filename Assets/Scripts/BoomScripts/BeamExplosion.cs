using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamExplosion : MonoBehaviour
{
    [SerializeField] private float expansionTime = 0.2f;
    [SerializeField] private float delay = 0.1f;
    [SerializeField] private float dispersionTime = 0.2f;

    private IEnumerator Start()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x, 0, scale.z);

        float t = 0;
        while (t < expansionTime)
        {
            t += Time.deltaTime;
            if (t>= expansionTime)
                t = expansionTime;

            transform.localScale = new Vector3(scale.x, Mathf.Lerp(0, scale.y, t / expansionTime), scale.z);
            yield return new WaitForEndOfFrame();
        }

        boxCollider.enabled = true;
        yield return new WaitForSeconds(delay);

        t = 0;
        while (t < dispersionTime)
        {
            t += Time.deltaTime;
            if (t >= dispersionTime)
                t = dispersionTime;

            transform.localScale = new Vector3(scale.x, Mathf.Lerp(scale.y, 0, t), scale.z);
            yield return new WaitForEndOfFrame();
        }

        NavMeshManager.Instance.NavMeshUpdata();

        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            Destroy(collision.gameObject);
        }
    }
}
