using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AmongUsRoomManager : NetworkRoomManager
{
    public override void OnRoomServerConnect(NetworkConnection conn)
    {
        base.OnRoomServerConnect(conn);

        //Vector3 spawnPos = FindObjectOfType<SpawnPositions>().GetSpawnPosition();

        //var player = Instantiate(spawnPrefabs[0], spawnPos, Quaternion.identity);
        //NetworkServer.Spawn(player, conn);
    }
}
