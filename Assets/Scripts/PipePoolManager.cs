using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This manager is responsible for the pool of pipepools, each pool of pipes has a couple of them inside and the manager passes 1 pipe from a random pipe pool.
public class PipePoolManager : MonoBehaviour
{
    public PipePool[] pipePools;

    public static PipePoolManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public PipeController Get()
    {
        int rand = Random.Range(0, pipePools.Length);

        return pipePools[rand].Get();
    }
}
