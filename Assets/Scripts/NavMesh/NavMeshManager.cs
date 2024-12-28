using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    public static NavMeshManager Instance;
    private NavMeshSurface surface;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        surface.hideEditorLogs = true;
        surface.BuildNavMesh();
    }

    public void NavMeshUpdata()
    {
        surface.UpdateNavMesh(surface.navMeshData);
        Debug.Log("UpdateMesh");
    }
}
