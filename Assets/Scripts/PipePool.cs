using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PipePool
{
    public PipeController pipePrefab;

    private Queue<PipeController> pipes = new Queue<PipeController>();

    //We call this method when we want to spawn a new pipe.
    public PipeController Get()
    {
        if (pipes.Count == 0)
        {
            AddPipe(1);
        }

        return pipes.Dequeue();
    }
    
    //Add pipe prefab to the pipes queue. 
    private void AddPipe(int count)
    {
        for (int i = 0; i < count; i++)
        {
            PipeController pipeController = MonoBehaviour.Instantiate(pipePrefab);
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
