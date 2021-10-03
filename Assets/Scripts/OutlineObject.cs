using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color outlineColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var inst = Instantiate(spriteRenderer.material);
        spriteRenderer.material = inst;
        spriteRenderer.material.SetColor("_OutlineColor", outlineColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterMover>();
        if(character != null && character.hasAuthority)
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterMover>();
        if (character != null && character.hasAuthority)
        {
            spriteRenderer.enabled = false;
        }
    }
}
