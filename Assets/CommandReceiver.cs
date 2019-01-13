using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Diese Klasse dient dazu die gesendeten Commands vom Sverer abzufangen
/// </summary>
public class CommandReceiver : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public MultiplayerServer server = new MultiplayerServer();
    /// <summary>
    /// This function will send a command to the multiplayer component
    /// </summary>
    /// <param name="command"></param>
    public void sendCommand(ICouchGamesCommand command)
    {
        switch (command.getCommandType())
        {
            case CouchGamesCommandType.Broadcast:
                server.sendToAll(command);
                break;
            case CouchGamesCommandType.ForHost:
                server.sendToHost(command);
                break;
            default:
                throw new InvalidEnumArgumentException();
        }
    }
    /// <summary>
    /// This function will be called by the Multiplayer component if a new command is received
    /// </summary>
    /// <param name="command"></param>
    public void recvCommand(ICouchGamesCommand command)
    {
        if (command is PlayerWantsToJoinCommand playerJoinCommand)
        {
            MainMenu mainMenu = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();
            mainMenu.playerJoined(playerJoinCommand.name, playerJoinCommand.gameId, playerJoinCommand.playerId);
        }
        else
        {
        }
    }
}

public enum CouchGamesCommandType { ForHost, Broadcast }

public interface ICouchGamesCommand : ISerializable
{
    CouchGamesCommandType getCommandType();
}
