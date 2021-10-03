using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCharacterMover : CharacterMover
{
    public void CompleteSpawn()
    {
        if(hasAuthority)
        {
            isMoveable = true;
        }
    }
}
