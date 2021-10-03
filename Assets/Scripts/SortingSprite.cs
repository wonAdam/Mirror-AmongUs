using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSprite : MonoBehaviour
{
    public enum ESortingType
    {
        Static,
        Update,
    }

    [SerializeField] private ESortingType sortingType;

    private SpriteSorter sorter;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private SpriteRenderer[] additionalRenderersAddOne;

    // Start is called before the first frame update
    void Start()
    {
        sorter = FindObjectOfType<SpriteSorter>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingOrder = sorter.GetSortingOrder(gameObject);

        foreach(var renderer in additionalRenderersAddOne)
            renderer.sortingOrder = sorter.GetSortingOrder(gameObject) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(sortingType == ESortingType.Update)
        {
            spriteRenderer.sortingOrder = sorter.GetSortingOrder(gameObject);

            foreach (var renderer in additionalRenderersAddOne)
                renderer.sortingOrder = sorter.GetSortingOrder(gameObject) + 1;
        }
    }
}
