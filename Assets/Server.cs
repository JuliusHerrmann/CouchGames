using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public interface IMultiplayerGameObject
{
    void recvCommand(ICouchGamesCommand command);
}
public class MultiplayerServer : MonoBehaviour
{
    protected enum MultiplayerServerBroadcastType
    {
        hostOnly = (Int16)1,
        all = (Int16)2,
    }
    protected IMultiplayerGameObject go;
    protected Dictionary<string, Type> allowedCommands;
    public MultiplayerServer(IMultiplayerGameObject go, Dictionary<string, Type> allowedCommands)
    {
        this.go = go;
        this.allowedCommands = allowedCommands;
    }

    protected WebSocket webSocket;
    IEnumerator Start()
    {
        // connect to server
        webSocket = new WebSocket(new Uri("ws://localhost:8000"));
        yield return StartCoroutine(webSocket.Connect());
        Debug.Log("CONNECTED TO WEBSOCKETS");

        // wait for messages
        while (true)
        {
            // read message
            string message = webSocket.RecvString();
            // check if message is not empty
            if (message != null)
            {
                this.recv(message);               
            }
            // Debug.Log("RECEIVED FROM WEBSOCKETS: " + reply);
            // if connection error, break the loop
            if (webSocket.error != null)
            {
                Debug.LogError("Error: " + webSocket.error);
                break;
            }


        }
    }

    private void recv(string message)
    {
        char[] charSeparators = new char[] { ':' };
        string[] msg = message.Split(charSeparators, 2);
        Type t = this.allowedCommands[msg[0]];

        //TODO 
        ICouchGamesCommand command = null;

        this.go.recvCommand(command);
    }

    public void sendToHost(ISerializable data)
    {
        this.send(MultiplayerServerBroadcastType.hostOnly, data);
    }

    private void send(MultiplayerServerBroadcastType type, ISerializable data)
    {
        string json = JsonUtility.ToJson(data);
        string className = data.GetType().ToString();

        webSocket.SendString(type.ToString() + ":" + className + ":" + json);
    }

    public void sendToAll(ISerializable data)
    {
        this.send(MultiplayerServerBroadcastType.all, data);
    }



}
