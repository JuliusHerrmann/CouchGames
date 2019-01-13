using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //List<Player> allPlayer = new List<Player>();
    int id;
    public GameObject playerList;
    // Start is called before the first frame update
    void Start()
    {
        id = 123456;
    }

    public void playerJoined(string name, int gameId, Guid playerId){
        //Überprüfen ob der Spiler dem korrekten Spiel beitreten möchte
        if(gameId != this.id){
            return;
        }
        Player p = new Player(name, true, Guid.NewGuid());
        p.UUid = playerId;
        playerList.GetComponent<PlayerList>().allePlayer.Add(p);
    }

    public void playerWantsToStart(Guid id){
        if(playerList.GetComponent<PlayerList>().allePlayer.Any(p => p.UUid == id))
        {
            //Start
            playerList.GetComponent<PlayerList>().gameId = this.id;
            SceneManager.LoadScene("Game");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
