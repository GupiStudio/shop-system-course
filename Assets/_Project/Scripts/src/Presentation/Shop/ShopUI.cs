using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopUI : MonoBehaviour
{
	[SerializeField] private ShopManager _shopManager;
	[SerializeField] private UserManager _userManager;
	
    [SerializeField]
    private float _itemSpacing = 0.5f;

    [SerializeField]
    private GameObject shopUI;

    [SerializeField]
    private Button buttonOpenShop;

    [SerializeField]
    private Button buttonCloseShop;

    [SerializeField]
    private Image _selectedCharacterIcon;

    [SerializeField]
    private Transform _shopItemsContainer;

    [SerializeField]
    private GameObject _itemPrefab;

    [SerializeField]
    private ParticleSystem _purchaseFX;

    [SerializeField]
    private Transform _purchaseFXPos;

    [SerializeField]
    private TMP_Text _notEnoughCoinText;
    
    private int _newSelectedItemIndex = 0;
    private int _previousSelectedItemIndex = 0;
	
    private float _itemHeight;

    private void Awake()
    {
	    Initialize();
        CloseShop();
    }

    private void Initialize()
	{
		_purchaseFX.transform.position = _purchaseFXPos.position;

        GenerateShopItemsUI();
	}

    private void OpenShop()
	{
		shopUI.SetActive(true);
	}

	private void CloseShop()
	{
		shopUI.SetActive(false);
	}

    private void GenerateShopItemsUI()
	{
		_itemHeight = _shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
		if (_shopItemsContainer.GetChild(0).gameObject)
			Destroy(_shopItemsContainer.GetChild(0).gameObject);

		var actorsInSale = _shopManager.GetActorsInsSale();

		var count = actorsInSale.Count;

		for (var i = 0; i < count; i++)
		{
			var character = actorsInSale[i];
			var uiItem = Instantiate(
				_itemPrefab,
				_shopItemsContainer
			).GetComponent<ShopItemUI>();

			uiItem.SetPosition(Vector2.down * i * (_itemHeight + _itemSpacing));

			uiItem.gameObject.name = "Item" + i + "-" + character.Name;

			uiItem.SetName(character.Name);
			uiItem.SetSpeed(character.Speed);
			uiItem.SetPower(character.Power);
			uiItem.SetPrice(character.Price);

			if (character.IsPurchased)
			{
				uiItem.SetAsPurchased();
				uiItem.OnSelect(i, OnItemSelected);
			}
			else
			{
				uiItem.SetPrice(character.Price);
				uiItem.OnPurchase(i, OnItemPurchase);
			}
		}

		_shopItemsContainer.GetComponent<RectTransform>().sizeDelta =
				Vector2.up * ((_itemHeight + _itemSpacing) * count + _itemSpacing);
	}

    private void OnItemSelected(int index)
	{
		SelectItemUI(index);
	}

	private void SelectItemUI(int index)
	{
		_previousSelectedItemIndex = _newSelectedItemIndex;
		_newSelectedItemIndex = index;

		var previousItem = GetItemUI(_previousSelectedItemIndex);
		var newItem = GetItemUI(_newSelectedItemIndex);

		previousItem.DeselectItem();
		newItem.SelectItem();
	}

	private ShopItemUI GetItemUI(int index)
	{
		return _shopItemsContainer.GetChild(index).GetComponent<ShopItemUI>();
	}

	private void OnItemPurchase(int index)
	{
		// var actor = _database.GetActor(index);
		// var uiItem = GetItemUI(index);
  //
  //       if (ShopManager.Instance.Purchase(index))
  //       {
  //           _purchaseFX.Play();
  //
		// 	// SharedUI.Instance.UpdateCoinsUITexts();
  //
		// 	uiItem.SetAsPurchased();
		// 	uiItem.OnSelect(index, OnItemSelected);
  //       }
		// else
		// {
		// 	ShowNotEnoughCoinMessage();
		// 	uiItem.PlayItemShakeAnimation();
		// }
	}

	private void ShowNotEnoughCoinMessage()
	{
		_notEnoughCoinText.DOComplete();
		_notEnoughCoinText.transform.DOComplete();

		_notEnoughCoinText.DOFade(1f, 2.5f).From(0f).OnComplete(() =>
		{
			_notEnoughCoinText.DOFade(0f, 1f);
		});

		_notEnoughCoinText.transform.DOShakePosition(3f, new Vector3(5f, 0f, 0f), 10, 0f);
	}
}
