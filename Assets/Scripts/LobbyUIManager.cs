using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    public static LobbyUIManager Instance;

    [SerializeField] private CustomizeUI customizeUI;
    public CustomizeUI CustomizeUI {  get { return customizeUI; } }

    [SerializeField] private Button useButton;
    [SerializeField] private Sprite originalUseButtonSprite;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUseButton(Sprite sprite, UnityAction action)
    {
        useButton.image.sprite = sprite;
        useButton.onClick.AddListener(action);
        useButton.interactable = true;
    }

    public void UnsetUseButton()
    {
        useButton.image.sprite = originalUseButtonSprite;
        useButton.onClick.RemoveAllListeners();
        useButton.interactable = false;
    }
}
