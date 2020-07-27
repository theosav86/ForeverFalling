using System.Collections;
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

    //getter 
    public PlayerBaseState CurrentState
    {
        get { return currentState; }
    }

    public Rigidbody Rigidbobody
    {
        get { return playerRigidbody; }
    }

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

    private void PlayerMovement()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + axisInput * playerMoveSpeed * Time.fixedDeltaTime);
    }

    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            currentState.OnTriggerEnter(this);
        }
    }

    public void PlayerDeath()
    {
        Debug.Log("You ded...");
        playerFallSpeed = 0f;

        EventBroker.CallPlayerHasDied();

        StartCoroutine("RestartGame");
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(3);

        SceneManager.LoadScene(0);
    }
}
