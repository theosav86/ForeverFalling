﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Variables

    private PlayerBaseState currentState;

    [SerializeField]
    private float playerMoveSpeed = 20f;

    public float speedBoostMultiplier;

    public float playerFallSpeed = 1f;

    private Vector3 axisInput;

    private Rigidbody playerRigidbody;

    #endregion

    //A getter for the current state 
    public PlayerBaseState CurrentState
    {
        get { return currentState; }
    }

    public Rigidbody Rigidbobody
    {
        get { return playerRigidbody; }
    }


    //Declaration of the possible states of the player
    public readonly PlayerNormalState normalState = new PlayerNormalState();

    public readonly PlayerBoostingState boostingState = new PlayerBoostingState();

    public readonly PlayerCrashState crashState = new PlayerCrashState();

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        TransitionToState(normalState);
    }

    // Update is called once per frame
    void Update()
    {
        
        axisInput.x = Input.GetAxisRaw("Horizontal");
        axisInput.y = Input.GetAxisRaw("Vertical");
        axisInput.z = playerFallSpeed * speedBoostMultiplier;

        currentState.Update(this);

    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    //Player movement function with WASD or arrow keys
    private void PlayerMovement()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + axisInput * playerMoveSpeed * Time.fixedDeltaTime);
    }

    //Method to swap states
    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    //Method that detects trigger collision
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            currentState.OnTriggerEnter(this);
        }
    }

    //Method that kills the player
    public void PlayerDeath()
    {
        Debug.Log("You ded...");
        playerFallSpeed = 0f;

        EventBroker.CallPlayerHasDied();

        StartCoroutine("RestartGame");
    }

    //Coroutine to wait 3 seconds and restart the game.
    private IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(3);

        SceneManager.LoadScene(0);
    }
}
