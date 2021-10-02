using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerColor
{ 
    Red, Blue, Green,
    Pink, Orange, Yellow,
    Brown, Cyan, Lime, 
    Black, White, Purple
}

public static class PlayerColor
{
    private static List<Color> colors = new List<Color>()
    {
        Color.red,
        Color.blue,
        Color.green,
        new Color(1f, 0.3f, 0.9f),
        new Color(1f, 0.4f, 0f),
        Color.yellow,
        new Color(0.7f, 0.2f, 0f),
        Color.cyan,
        new Color(0.1f, 1f, 0.1f),
        Color.black,
        Color.white,
        new Color(0.6f, 0f, 0.6f)
    };

    public static Color GetColor(EPlayerColor playerColor) { return colors[(int)playerColor]; }
    public static Color Red { get => colors[(int)EPlayerColor.Red]; }
    public static Color Blue { get => colors[(int)EPlayerColor.Blue]; }
    public static Color Green { get => colors[(int)EPlayerColor.Green]; }
    public static Color Pink { get => colors[(int)EPlayerColor.Pink]; }
    public static Color Orange { get => colors[(int)EPlayerColor.Orange]; }
    public static Color Yellow { get => colors[(int)EPlayerColor.Yellow]; }
    public static Color Brown { get => colors[(int)EPlayerColor.Brown]; }
    public static Color Cyan { get => colors[(int)EPlayerColor.Cyan]; }
    public static Color Lime { get => colors[(int)EPlayerColor.Lime]; }
    public static Color Black { get => colors[(int)EPlayerColor.Black]; }
    public static Color White { get => colors[(int)EPlayerColor.White]; }
    public static Color Purple { get => colors[(int)EPlayerColor.Purple]; }
}
