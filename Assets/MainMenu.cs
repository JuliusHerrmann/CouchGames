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

    public Guid playerJoined(string name, int id){
        //Überprüfen ob der Spiler dem korrekten Spiel beitreten möchte
        if(id != this.id){
            return new Guid("00000000-0000-0000-0000-000000000000");
        }
        Player p = new Player(name, true, new Guid());
        //allPlayer.Add(p);
        playerList.GetComponent<PlayerList>().allePlayer.Add(p);
        return p.UUid;
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
