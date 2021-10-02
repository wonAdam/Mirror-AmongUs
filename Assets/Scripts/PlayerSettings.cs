using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum EControlType
{
    MouseControl,
    KeyboardMouse,
}

public class PlayerSettings
{

    public static EControlType controlType;

    public static string nickname;
}
