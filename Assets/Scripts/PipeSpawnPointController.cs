﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnPointController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    { 

        if (collider.CompareTag("Player"))
        {
            PipeController spawnNewPipe = PipePoolManager.Instance.Get();
            spawnNewPipe.transform.position = transform.position + new Vector3(0f, 0f, 500f);
            spawnNewPipe.transform.rotation = transform.rotation;
            spawnNewPipe.gameObject.SetActive(true);

            Debug.Log("Spawning new pipe");
        }
    }
}
