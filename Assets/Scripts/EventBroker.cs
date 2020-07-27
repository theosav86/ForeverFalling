using System;


public class EventBroker
{
    //Event to be called when the player crashes to an obstacle
    public static event Action PlayerHasDied;


    public static void CallPlayerHasDied()
    {
        if(PlayerHasDied != null)
        {
            PlayerHasDied();
        }
    }

}
