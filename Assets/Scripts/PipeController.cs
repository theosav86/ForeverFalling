using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{

    private Vector3 pipeOffSet = new Vector3(0, 0, 100f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            PipePool.Instance.ReturnToPool(this);
        }

        PipeController newPipe = PipePool.Instance.Get();
        newPipe.transform.position = transform.position + pipeOffSet;
        newPipe.transform.rotation = transform.rotation;
        newPipe.gameObject.SetActive(true);
    }
}
