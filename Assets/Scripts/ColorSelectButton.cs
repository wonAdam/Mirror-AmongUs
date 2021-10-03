using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButton : MonoBehaviour
{
    private EPlayerColor color;
    public EPlayerColor Color {
        get { return color; }
        set { 
            GetComponent<Image>().color = PlayerColor.GetColor(value);
            color = value;
        }
    }

    [SerializeField] private GameObject x;

    public bool isInteractable = true;

    private void Start()
    {
        GetComponent<Image>().color = PlayerColor.GetColor(color);
    }

    public void SetInteractable(bool isInteractable)
    {
        this.isInteractable = isInteractable;
        x.SetActive(!isInteractable);
    }
}
