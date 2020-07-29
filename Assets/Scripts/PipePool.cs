﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    [SerializeField]
    private PipeController pipePrefab;

    private Queue<PipeController> pipes = new Queue<PipeController>();

    //public int poolCount;


    //basic singleton of PipePool
    public static PipePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //We call this method when we want to spawn a new pipe.
    public PipeController Get()
    {
        if (pipes.Count == 0)
        {
            AddPipe(2);
        }

        return pipes.Dequeue();
    }
    
    //Add pipe prefab to the pipes queue. 
    private void AddPipe(int count)
    {
        for (int i = 0; i < count; i++)
        {
            PipeController pipeController = Instantiate(pipePrefab);
            pipeController.gameObject.SetActive(false);
            pipes.Enqueue(pipeController);
        }
    }

    //Instead of destroying the pipe we return it to the pool
    public void ReturnToPool(PipeController pipeController)
    {
        pipeController.gameObject.SetActive(false);
        pipes.Enqueue(pipeController);
    }
}
