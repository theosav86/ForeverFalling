using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        player.speedBoostMultiplier = 1f;
    }

    public override void OnTriggerEnter(PlayerController player)
    {
        player.TransitionToState(player.crashState);
    }

    public override void Update(PlayerController player)
    {
        if(Input.GetButtonDown("Thrust"))
        {
            player.TransitionToState(player.boostingState);
        }
    }
}
