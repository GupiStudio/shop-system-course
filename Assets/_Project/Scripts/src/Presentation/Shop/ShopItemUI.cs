using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Froggi.Game;
using UnityEngine.Events;

namespace Froggi.Presentation
{
	public class ShopItemUI : MonoBehaviour
	{
		[SerializeField] private Color _itemNotSelected;

		[SerializeField] private Color _itemSelected;

		[Space(20f)] [SerializeField] private Image _image;

		[SerializeField] private TMP_Text _name;

		[SerializeField] private Image _speed;

		[SerializeField] private Image _power;

		[SerializeField] private TMP_Text _price;

		[SerializeField] private Button _purchase;

		[Space(20f)] [SerializeField] private Button _itemButton;

		[SerializeField] private Image _itemImage;

		[SerializeField] private Outline _itemOutline;

		private ActorData _actorData;
		private bool _isSelected;

		public void Initialize(int itemIndex, Sprite avatar, ActorData actorData, UnityAction<int> onSelect = null,
			UnityAction<int> onPurchase = null)
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

				_name.text = value.Name;
				_speed.fillAmount = value.Speed / 100f;
				_power.fillAmount = value.Power / 100f;
				_price.text = value.Price.ToString();

				if (_actorData.IsPurchased)
					SetAsPurchased();
			}
		}

		public bool IsPurchased
		{
			get => ActorData.IsPurchased;
			set
			{
				var data = ActorData;
				data.IsPurchased = value;
				ActorData = data;
			}
		}

		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				_isSelected = value;
				_itemOutline.enabled = _isSelected;
				_itemImage.color = _itemSelected;
				_itemButton.interactable = !_isSelected;
			}
		}

		public void SetPosition(Vector2 pos)
		{
			GetComponent<RectTransform>().anchoredPosition += pos;
		}

		public void PlayItemShakeAnimation()
		{
			transform.DOComplete();

			transform.DOShakePosition(1f, new Vector3(8f, 0f, 0f)).SetEase(Ease.Linear);
		}

		private void SetSprite(Sprite sprite)
		{
			_image.sprite = sprite;
		}

		private void SetAsPurchased()
		{
			_purchase.gameObject.SetActive(false);
			_itemButton.interactable = true;

			_itemImage.color = _itemNotSelected;
		}
	}
}
