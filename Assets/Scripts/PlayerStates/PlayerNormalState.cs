using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Player's normal 'Falling' state
public class PlayerNormalState : PlayerBaseState
{
    //normal multiplier for falling speed
    public override void EnterState(PlayerController player)
    {
        player.speedBoostMultiplier = 1f;
    }

    //on trigger enter check crashed state
    public override void OnTriggerEnter(PlayerController player)
    {
        player.TransitionToState(player.crashState);
    }

    //Thrust is SpaceBar and the players goes to boosting state
    public override void Update(PlayerController player)
    {
        if(Input.GetButtonDown("Thrust"))
        {
            player.TransitionToState(player.boostingState);
        }
    }
}
