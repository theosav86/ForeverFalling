using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public static PipePool pipePool;
    private Vector3 pipeOffSet = new Vector3(0, 0, 100f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            pipePool.ReturnToPool(this);
        }
    }
}
