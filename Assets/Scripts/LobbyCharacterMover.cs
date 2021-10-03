using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;

public class LobbyCharacterMover : CharacterMover
{
    [SyncVar(hook = nameof(SetOwnerNetId_Hook))]
    public uint ownerNetId;

    public void SetOwnerNetId_Hook(uint _, uint newOwnerId)
    {
        var player = FindObjectsOfType<AmongUsRoomPlayer>().First(player => player.hasAuthority);

        player.lobbyPlayerCharacter = this;
    }

    public void CompleteSpawn()
    {
        if(hasAuthority)
        {
            isMoveable = true;
        }
    }
}
