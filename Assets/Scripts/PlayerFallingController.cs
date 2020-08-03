using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingController : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    [SerializeField]
    private float fallSpeed = 20f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
