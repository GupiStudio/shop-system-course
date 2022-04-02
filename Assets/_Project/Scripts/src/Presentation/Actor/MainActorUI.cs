using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainActorUI : MonoBehaviour
{
    [SerializeField]
    private Image imageHolder;

    [SerializeField]
    private TMP_Text nameHolder;

    private void SetImage(Sprite sprite)
    {
        if (imageHolder)
            imageHolder.sprite = sprite;
    }

    private void SetName(string newName)
    {
        if (nameHolder)
            nameHolder.text = newName;
    }
}
