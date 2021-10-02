using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    private Vector2 position;
    private BattleActorTemplate battleActor;

    public void SetCellPosition(Vector2 position, Vector2 offset, Color[] colors, Sprite cellBG)
    {
        this.position = position;
        transform.position = position - offset;
        
        SetCellVisual(colors[0], colors[1], cellBG);
    }

    private void SetCellVisual(Color evenColor, Color oddColor, Sprite sprite)
    {
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprite;

        if(position.x % 2 == 0)
        {
            if(position.y % 2 == 0)
            {
                spriteRenderer.color = evenColor;
            } else
            {
                spriteRenderer.color = oddColor;
            }
        } else
        {
            if(position.y % 2 == 0)
            {
                spriteRenderer.color = oddColor;
            } else
            {
                spriteRenderer.color = evenColor;
            }
        }
    }
}
