using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRoomSettings : SettingsUI
{
    private void Start()
    {
        MouseControlButton.onClick.AddListener(() => { SetControlMode(EControlType.MouseControl); });
        KeyboardMouseControlButton.onClick.AddListener(() => { SetControlMode(EControlType.KeyboardMouse); });
    }

    public void ExitGameRoom()
    {
        var manager = AmongUsRoomManager.singleton;
        if(manager.mode == NetworkManagerMode.Host)
        {
            manager.StopHost();
        }
        else
        {
            manager.StopClient();
        }
    }
}
