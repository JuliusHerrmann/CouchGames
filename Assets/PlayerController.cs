using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class PlayerController : MonoBehaviour
{
    public List<Player> allePlayer = new List<Player>();
    public GameObject timer;
    public List<GameObject> playerSigns = new List<GameObject>();
    public bool timeUp = false;
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

    public void startTimer(){
        StartCoroutine(start());
    }

    public int seconds = 60;
    IEnumerator start(){
        while(seconds > 0){
            timer.GetComponent<TextMeshProUGUI>().text = seconds.ToString();
            seconds--;
            yield return new WaitForSeconds(1);
        }
        timeUp = true;
    }
}
