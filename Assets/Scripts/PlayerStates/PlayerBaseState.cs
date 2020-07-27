using UnityEngine;

//Class that defines the various methods of the states
public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerController player);

    public abstract void Update(PlayerController player);

    public abstract void OnTriggerEnter(PlayerController player);
}
