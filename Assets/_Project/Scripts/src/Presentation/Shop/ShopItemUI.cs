using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;
using UnityEngine.Events;

public class ShopItemUI : MonoBehaviour
{
	[SerializeField] private Color _itemNotSelected;

	[SerializeField] private Color _itemSelected;

	[Space(20f)]
	[SerializeField] private Image _image;

	[SerializeField] private TMP_Text _name;

	[SerializeField] private Image _speed;

	[SerializeField] private Image _power;

	[SerializeField] private TMP_Text _price;

	[SerializeField] private Button _purchase;

	[Space(20f)]
	[SerializeField] private Button _itemButton;

	[SerializeField] private Image _itemImage;

	[SerializeField] private Outline _itemOutline;

	private ActorData _actorData;

	public void Initialize(int itemIndex, Sprite avatar, ActorData actorData, UnityAction<int> onSelect = null, UnityAction<int> onPurchase = null)
	{
		_purchase.onClick.RemoveAllListeners();
		_purchase.onClick.AddListener(() => onPurchase?.Invoke(itemIndex));

		_itemButton.onClick.RemoveAllListeners();
		_itemButton.onClick.AddListener(() => onSelect?.Invoke(itemIndex));

		SetSprite(avatar);
		ActorData = actorData;
	}

	public ActorData ActorData
	{
		get => _actorData;
		set
		{
			_actorData = value;

			SetName(_actorData.Name);
			SetSpeed(_actorData.Speed);
			SetPower(_actorData.Power);
			SetPrice(_actorData.Price);

			if (_actorData.IsPurchased)
				SetAsPurchased();
		}
	}

	public void SetPosition(Vector2 pos)
	{
		GetComponent<RectTransform>().anchoredPosition += pos;
	}

	public void SetSprite(Sprite sprite)
	{
		_image.sprite = sprite;
	}

	private void SetName(string name)
	{
		_name.text = name;
	}

	private void SetSpeed(int value)
	{
		_speed.fillAmount = value / 100f;
	}

	private void SetPower(int value)
	{
		_power.fillAmount = value / 100f;
	}

	private void SetPrice(int value)
	{
		_price.text = value.ToString();
	}

	private void SetAsPurchased()
	{
		_purchase.gameObject.SetActive(false);
		_itemButton.interactable = true;

		_itemImage.color = _itemNotSelected;
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

	public void PlayItemShakeAnimation()
	{
		transform.DOComplete();

		transform.DOShakePosition(1f, new Vector3(8f, 0f, 0f)).SetEase(Ease.Linear);
	}
}
