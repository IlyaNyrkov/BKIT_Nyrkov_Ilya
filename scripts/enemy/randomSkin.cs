using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSkin : MonoBehaviour
{
    public List<Sprite> sprites;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        System.Random random = new System.Random();
        int index = random.Next(10);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
        spriteRenderer.sprite = sprites[random.Next(sprites.Count)];
    }
}
