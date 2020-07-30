using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PipeController spawnNewPipe = PipePoolManager.Instance.Get();
            spawnNewPipe.transform.position = Vector3.zero;
            spawnNewPipe.transform.rotation = transform.rotation;
            spawnNewPipe.gameObject.SetActive(true);

            Debug.Log("Spawning new pipe");
        }
    }
}
