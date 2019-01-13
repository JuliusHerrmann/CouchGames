using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

public class PlayerWantsToJoinCommand : ICouchGamesCommand
{
    public string name { get; set; }
    public int gameId { get; set; }
    public Guid playerId { get; set; }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }

    public CouchGamesCommandType getCommandType()
    {
        return CouchGamesCommandType.ForHost;
    }
}
