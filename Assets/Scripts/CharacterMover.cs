using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;

public class CharacterMover : NetworkBehaviour
{
    public bool isMoveable;

    private Animator animator;

    [SyncVar]
    public float speed = 2f;

    private SpriteRenderer spriteRenderer;

    [SyncVar(hook = nameof(SetPlayerColor_Hook))]
    public EPlayerColor playerColor;

    private void SetPlayerColor_Hook(EPlayerColor oldColor, EPlayerColor newColor)
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(newColor));
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));

        animator = GetComponent<Animator>();

        if (hasAuthority)
        {
            Camera cam = Camera.main;
            cam.transform.SetParent(transform);
            cam.transform.localPosition = new Vector3(0f, 0f, -10f);
            cam.orthographicSize = 2.5f;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if(hasAuthority && isMoveable)
        {
            bool isMove = false;
            if(PlayerSettings.controlType == EControlType.KeyboardMouse)
            {
                Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 1f);
                if (dir.x < 0f) transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
                else transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                transform.position += dir * speed * Time.deltaTime;

                isMove = dir.magnitude != 0f;
            }

            else
            {
                if(Input.GetMouseButton(0))
                {

                    Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)).normalized;
                    transform.position += dir * speed * Time.deltaTime;

                    if (dir.x < 0f) transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
                    else transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                    isMove = dir.magnitude != 0f;

                }
            }

            animator.SetBool("isMove", isMove);
        }
    }
}
