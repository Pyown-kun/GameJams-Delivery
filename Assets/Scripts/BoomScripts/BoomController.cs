using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    [SerializeField] private GameObject beam;
    [SerializeField] private GameObject beamEnd;
    [SerializeField] private float timeBeforeExplode;

    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask breakableLayer;

    [field : SerializeField] public float Range { get; set; } = 3;

    private void Update()
    {
        timeBeforeExplode -= Time.deltaTime;

        if (timeBeforeExplode <= 0)
        {
            AudioManager.Instance.Explosion.Play();
            Detonate();
            Destroy(gameObject);
        }
    }

    private void Detonate()
    {
        Spread(Vector2.up);
        Spread(Vector2.down);
        Spread(Vector2.right);
        Spread(Vector2.left);
    }

    private void Spread(Vector2 dir)
    {
        Vector2 origin = transform.position;

        RaycastHit2D wallHit = Physics2D.Raycast(origin, dir, Range, wallLayer);
        RaycastHit2D breakableHit = Physics2D.Raycast(origin, dir, Range, breakableLayer);
        bool hitbreakable = breakableHit.collider;
        bool hitWall = wallHit.collider;

        if (hitbreakable && hitWall)
        {
            if (wallHit.distance < breakableHit.distance)
            {
                hitbreakable = false;
            }
            else
            {
                hitWall = true;
            }
        }

        if (hitWall)
        {
            float dist = (wallHit.point - origin).magnitude;

            if (dist <= 1.0f)
                return;

            Vector2 pos = (wallHit.point - dir * 0.5f);
            InsantiateBeem(pos, dir, true);

            for (int i = 1; i < dist - 1; ++i)
            {
                InsantiateBeem(pos - i * dir, dir, false);
            }
        }
        else if (hitbreakable)
        {
            float dist = (breakableHit.point - origin).magnitude;

            Vector2 pos = (wallHit.point - dir * 0.5f);
            InsantiateBeem(pos, dir, true);

            for (int i = 1; i < dist - 1; ++i)
            {
                InsantiateBeem(pos - i * dir, dir, false);
            }
        }
        else
        {
            Vector2 pos = (Vector2)transform.position + dir * Range;
            InsantiateBeem(pos, dir, true );

            int i = 1;

            while((pos - (Vector2)transform.position).magnitude > 1.0f)
            {
                pos -= i * dir;
                InsantiateBeem(pos, dir, false);
            }
        }

    }
    private void InsantiateBeem(Vector2 pos, Vector2 dir, bool end)
    {
        Quaternion quat = Quaternion.identity;

        if (dir == Vector2.up)
        {
            quat = Quaternion.Euler(0, 0, -90f);
        }
        if (dir == Vector2.down)
        {
            quat = Quaternion.Euler(0, 0, 90f);
        }
        if (dir == Vector2.right)
        {
            quat = Quaternion.Euler(0, 0, 180f);
        }

        Instantiate(end ? beamEnd : beam, pos, quat);
    }
}
