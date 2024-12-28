using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private void Start()
    {
        Physics2D.SyncTransforms();
        NavMeshManager.Instance.NavMeshUpdata();
    }

}
