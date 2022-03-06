using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class CharacterItem : MonoBehaviour
{
    [SerializeField]
    private Color _itemNotSelected;

    [SerializeField]
    private Color _itemSelected;

    [Space(20f)]
    [SerializeField]
    private Image _image;

    [SerializeField]
    private TMP_Text _name;

    [SerializeField]
    private Image _speed;

    [SerializeField]
    private Image _power;

    [SerializeField]
    private TMP_Text _price;

    [SerializeField]
    private Button _purchase;

    [Space(20f)]
    [SerializeField]
    private Button _itemButton;

    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private Outline _itemOutline;

    public void SetPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetSpeed(int value)
    {
        _speed.fillAmount = value / 100f;
    }

    public void SetPower(int value)
    {
        _power.fillAmount = value / 100f;
    }

    public void SetPrice(int value)
    {
        _price.text = value.ToString();
    }

    public void SetAsPurchased()
    {
        _purchase.gameObject.SetActive(false);
        _itemButton.interactable = true;

        _itemImage.color = _itemNotSelected;
    }

    public void OnPurchase(int itemIndex, UnityAction<int> action)
    {
        _purchase.onClick.RemoveAllListeners();
        _purchase.onClick.AddListener(() => action.Invoke(itemIndex));
    }

    public void OnSelect(int itemIndex, UnityAction<int> action)
    {
        _itemButton.interactable = true;
        _itemButton.onClick.RemoveAllListeners();
        _itemButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }

    public void SelectItem()
    {
        _itemOutline.enabled = true;
        _itemImage.color = _itemSelected;
        _itemButton.interactable = false;
    }

    public void DeselectItem()
    {
        _itemOutline.enabled = false;
        _itemImage.color = _itemNotSelected;
        _itemButton.interactable = true;
    }
}
