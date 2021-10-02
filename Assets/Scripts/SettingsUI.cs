using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    protected Button MouseControlButton;
    [SerializeField]
    protected Button KeyboardMouseControlButton;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        MouseControlButton.onClick.AddListener(() => { SetControlMode(EControlType.MouseControl); });
        KeyboardMouseControlButton.onClick.AddListener(() => { SetControlMode(EControlType.KeyboardMouse); });
    }

    private void OnEnable()
    {
        switch(PlayerSettings.controlType)
        {
            case EControlType.KeyboardMouse:
                {
                    MouseControlButton.image.color = Color.white;
                    KeyboardMouseControlButton.image.color = Color.green;
                    break;
                }

            case EControlType.MouseControl:
                {
                    MouseControlButton.image.color = Color.green;
                    KeyboardMouseControlButton.image.color = Color.white;
                    break;
                }
        }
    }

    public void SetControlMode(EControlType controlType)
    {
        PlayerSettings.controlType = controlType;

        switch (PlayerSettings.controlType)
        {
            case EControlType.KeyboardMouse:
                {
                    MouseControlButton.image.color = Color.white;
                    KeyboardMouseControlButton.image.color = Color.green;
                    break;
                }

            case EControlType.MouseControl:
                {
                    MouseControlButton.image.color = Color.green;
                    KeyboardMouseControlButton.image.color = Color.white;
                    break;
                }
        }
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("Close");
    }
}
