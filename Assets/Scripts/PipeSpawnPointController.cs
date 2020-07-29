using System.Collections;
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
            PipeController newPipe = PipePool.Instance.Get();
            newPipe.transform.position = transform.position;
            newPipe.transform.rotation = transform.rotation;
            newPipe.gameObject.SetActive(true);

            Debug.Log("Spawning new pipe");
        }
    }
}
