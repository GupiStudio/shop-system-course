using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ShopController : MonoBehaviour
{
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

    private ActorsDatabase _database;

    private float _itemHeight;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
	{
		buttonOpenShop.onClick.RemoveAllListeners();
		buttonCloseShop.onClick.RemoveAllListeners();

		buttonOpenShop.onClick.AddListener(OpenShop);
		buttonCloseShop.onClick.AddListener(CloseShop);

        _database = ShopManager.Instance.Database;

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
		ShopManager.Instance.FetchSavedShopDataToDatabase();

		_itemHeight = _shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
		Destroy(_shopItemsContainer.GetChild(0).gameObject);

		int count = _database.ActorsCount;

		for (int i = 0; i < count; i++)
		{
			var character = _database.GetActor(i);
			var uiItem = Instantiate(
				_itemPrefab,
				_shopItemsContainer
			).GetComponent<ActorItemUIController>();

			uiItem.SetPosition(Vector2.down * i * (_itemHeight + _itemSpacing));

			uiItem.gameObject.name = "Item" + i + "-" + character.Name;

			uiItem.SetName(character.Name);
			uiItem.SetSprite(character.Image);
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

		// DataManager.SetSelectedCharacter(_database.GetActor(index), index);

        // GameManager.Instance.ChangePlayerSkin();
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

	private ActorItemUIController GetItemUI(int index)
	{
		return _shopItemsContainer.GetChild(index).GetComponent<ActorItemUIController>();
	}

	private void OnItemPurchase(int index)
	{
		var actor = _database.GetActor(index);
		var uiItem = GetItemUI(index);

        if (ShopManager.Instance.Purchase(index))
        {
            _purchaseFX.Play();

			// SharedUI.Instance.UpdateCoinsUITexts();

			uiItem.SetAsPurchased();
			uiItem.OnSelect(index, OnItemSelected);
        }
		else
		{
			ShowNotEnoughCoinMessage();
			uiItem.PlayItemShakeAnimation();
		}
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
