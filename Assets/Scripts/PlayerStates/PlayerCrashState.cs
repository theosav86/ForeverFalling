using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrashState : PlayerBaseState
{
    //Player crashed run player's death method
    public override void EnterState(PlayerController player)
    {
        player.PlayerDeath();
    }

    public override void OnTriggerEnter(PlayerController player)
    {
       
    }

    public override void Update(PlayerController player)
    {
    }
}
