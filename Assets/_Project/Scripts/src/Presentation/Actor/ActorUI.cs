using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActorUI : MonoBehaviour, IActorUI
{
    [SerializeField] private Image _imageHolder;

    [SerializeField] private TMP_Text _nameHolder;

    public Sprite Graphic
    {
        get => _imageHolder ? _imageHolder.sprite : null;
        set
        {
            if (_imageHolder)
                _imageHolder.sprite = value;
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