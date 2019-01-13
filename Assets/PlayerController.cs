using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class PlayerController : MonoBehaviour
{
    public List<Player> allePlayer = new List<Player>();
    public List<GameObject> playerSigns = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {   
        //playerSigns[0].GetComponent<TextMeshProUGUI>().text = allePlayer[0].name + "\t" + allePlayer[0].points;
        //startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
