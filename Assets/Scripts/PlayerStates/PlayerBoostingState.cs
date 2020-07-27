using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostingState : PlayerBaseState
{
    //Doubled multiplier for boosting state
    public override void EnterState(PlayerController player)
    {
        player.speedBoostMultiplier = 2f;
    }
    
    //check crashed state
    public override void OnTriggerEnter(PlayerController player)
    {
        player.TransitionToState(player.crashState);
    }

    //If player is boosting and he presses spacebar again then go to normal state
    public override void Update(PlayerController player)
    {
        if(Input.GetButtonDown("Thrust"))
        {
            player.TransitionToState(player.normalState);
        }
    }
}
