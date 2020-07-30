using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//THIS CLASS NOW WORKS AS A HUD CONTROLLER MOSTLY... MOSTLY...



public class SceneController : MonoBehaviour
{

    public TextMeshProUGUI deathText;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        EventBroker.PlayerHasDied += EventBroker_PlayerHasDied;
    }

    private void EventBroker_PlayerHasDied()
    {
        deathText.alpha = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
