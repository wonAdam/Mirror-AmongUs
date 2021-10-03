using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;

public class CustomizeUI : MonoBehaviour
{
    [SerializeField] private Image characterPreview;

    [SerializeField] private List<ColorSelectButton> colorSelectButtons;

    // Start is called before the first frame update
    void Start()
    {
        var inst = Instantiate(characterPreview.material);
        characterPreview.material = inst;

        UpdateColorButton();
    }

    private void OnEnable()
    {
        UpdateColorButton();

        var roomSlots = ((AmongUsRoomManager)NetworkManager.singleton).roomSlots;
        foreach(var player in roomSlots)
        {
            var aPlayer = player as AmongUsRoomPlayer;
            if(aPlayer.isLocalPlayer)
            {
                UpdatePreviewColor(aPlayer.playerColor);
                break;
            }
        }
    }

    public void UpdateColorButton()
    {
        for(int i = 0; i < Enum.GetValues(typeof(EPlayerColor)).Length; ++i)
        {
            colorSelectButtons[i].SetInteractable(true);
            colorSelectButtons[i].Color = (EPlayerColor)Enum.GetValues(typeof(EPlayerColor)).GetValue(i);
        }

        var roomSlots = ((AmongUsRoomManager)NetworkManager.singleton).roomSlots;
        foreach (var player in roomSlots)
        {
            var aPlayer = player as AmongUsRoomPlayer;
            colorSelectButtons[(int)aPlayer.playerColor].SetInteractable(false);
        }
    }

    public void UpdatePreviewColor(EPlayerColor color)
    {
        characterPreview.material.SetColor("_PlayerColor", PlayerColor.GetColor(color));
    }

    public void OnClickColorButton(int index)
    {
        if(colorSelectButtons[index].isInteractable)
        {
            AmongUsRoomPlayer.MyRoomPlayer.CmdSetPlayerColor((EPlayerColor)index);
            UpdateColorButton();
        }
    }


    public void Open()
    {
        AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerCharacter.isMoveable = false;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerCharacter.isMoveable = true;
        gameObject.SetActive(false);

    }
}
