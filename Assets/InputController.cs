using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public string gameId, name;
    public GameObject idObj, nameObj, speicher;
    // Start is called be   fore the first frame update

    public void Start()
    {
        speicher = GameObject.FindGameObjectWithTag("Speicher");
    }

    public void enter()
    {
        if(string.IsNullOrEmpty(idObj.GetComponent<TMP_InputField>().text) || string.IsNullOrEmpty(nameObj.GetComponent<TMP_InputField>().text))
        {
            return;
        }
        //Push to server
        name = nameObj.GetComponent<TMP_InputField>().text;
        gameId = idObj.GetComponent<TMP_InputField>().text;
        Int32.TryParse(gameId,out speicher.GetComponent<speicherHandyScript>().gameId);
        SceneManager.LoadScene("ClientStart");
    }

    public void gameStart()
    {
        //Send to server: playerWantsToStart
        //Load next scene
        SceneManager.LoadScene("Gamepad");
    }
}
