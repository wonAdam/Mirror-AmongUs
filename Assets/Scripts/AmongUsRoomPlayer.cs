using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;

public class AmongUsRoomPlayer : NetworkRoomPlayer
{
    private static AmongUsRoomPlayer myRoomPlayer;

    public static AmongUsRoomPlayer MyRoomPlayer
    {
        get
        {
            if(myRoomPlayer == null)
            {
                var player = FindObjectsOfType<AmongUsRoomPlayer>().First(player => player.hasAuthority);
                myRoomPlayer = player;
            }

            return myRoomPlayer;
        }
    }

    [SyncVar(hook = nameof(SetPlayerColor_Hook))]
    public EPlayerColor playerColor;

    public void SetPlayerColor_Hook(EPlayerColor oldColor, EPlayerColor newColor)
    {
        LobbyUIManager.Instance.CustomizeUI.UpdateColorButton();
    }

    public CharacterMover lobbyPlayerCharacter;

    private void Start()
    {
        base.Start();

        if(isServer)
        {
            SpawnLobbyPlayerCharacter();
        }
    }

    [Command]
    public void CmdSetPlayerColor(EPlayerColor color)
    {
        playerColor = color;

        lobbyPlayerCharacter.playerColor = color;
    }

    private void SpawnLobbyPlayerCharacter()
    {
        playerColor = GetAvailablePlayerColor();

        Vector3 spawnPos = FindObjectOfType<SpawnPositions>().GetSpawnPosition();

        var playerCharacter = Instantiate(AmongUsRoomManager.singleton.spawnPrefabs[0], spawnPos, Quaternion.identity).GetComponent<LobbyCharacterMover>();
        NetworkServer.Spawn(playerCharacter.gameObject, connectionToClient);
        playerCharacter.ownerNetId = netId;
        playerCharacter.playerColor = playerColor;
    }

    private EPlayerColor GetAvailablePlayerColor()
    {
        var roomSlots = ((AmongUsRoomManager)NetworkManager.singleton).roomSlots;
        List<EPlayerColor> allColors = new List<EPlayerColor>();
        foreach (var color in Enum.GetValues(typeof(EPlayerColor)))
            allColors.Add((EPlayerColor)color);

        EPlayerColor availableColor = allColors.Find(color => !roomSlots.Select(slot => ((AmongUsRoomPlayer)slot).playerColor).Contains(color));

        return availableColor;
    }
}
