using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//THIS CLASS SHOULD SPAWN A NUMBER OF PIPES
//EACH PIPE SHOULD HAVE A RANDOM OBSTACLE FROM AN OBSTACLE POOL OR ARRAY OR LIST OR W/E


public class SceneController : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI deathText;
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
