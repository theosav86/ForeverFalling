using System;


public class EventBroker
{
    public static event Action PlayerHasDied;


    public static void CallPlayerHasDied()
    {
        if(PlayerHasDied != null)
        {
            PlayerHasDied();
        }
    }

}
