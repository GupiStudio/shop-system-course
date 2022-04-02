using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameActorUI : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private TMP_Text nameHolder;

    public void SetImage(Sprite sprite)
    {
        if (spriteRenderer)
            spriteRenderer.sprite = sprite;
    }

    public void SetName(string newName)
    {
        if (nameHolder)
            nameHolder.text = newName;
    }
}
