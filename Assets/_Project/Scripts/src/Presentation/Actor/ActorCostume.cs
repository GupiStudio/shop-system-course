using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActorCostume : MonoBehaviour, IActorUI
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private TMP_Text _nameHolder;

    public Sprite Graphic
    {
        get => _spriteRenderer ? _spriteRenderer.sprite : null;
        set
        {
            if (_spriteRenderer)
                _spriteRenderer.sprite = value;
        }
    }

    public string Name
    {
        get => _nameHolder ? _nameHolder.text : string.Empty;
        set
        {
            if (_nameHolder)
                _nameHolder.text = value;
        }
    }
}
