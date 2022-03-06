using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{
    [Header("Layout Settings")]

    [SerializeField] private float _itemSpacing = 0.5f;

    [Header("UI Elements")]

    [SerializeField] private Image _selectedCharacterIcon;
    [SerializeField] private Transform _shopItemsContainer;
    [SerializeField] private GameObject _itemPrefab;

    [Space(20f)]

    [SerializeField] private CharacterShopDatabase _database;

    [Header("Shop Events")]
    
    [SerializeField] private GameObject shopUI;
    [SerializeField] private Button buttonOpenShop;
    [SerializeField] private Button buttonCloseShop;

    [Space(20f)]
    [Header("Main Menu")]
    
    [SerializeField] private Image _mainMenuCharacterImage;
    [SerializeField] private TMP_Text _mainMenuCharacterName;

    private float _itemHeight;
    private int _newSelectedItemIndex = 0;
    private int _previousSelectedItemIndex = 0;

    void Start()
    {
        AddShopEvents();
        GenerateShopItemsUI();
        SetSelectedCharacter();

        SelectItemUI(DataManager.GetSelectedCharacterIndex());

        ChangePlayerSkin();
    }

    private void SetSelectedCharacter()
    {
        int index = DataManager.GetSelectedCharacterIndex();

        DataManager.SetSelectedCharacter(_database.GetCharacter(index), index);
    }

    private void GenerateShopItemsUI()
    {
        MatchDatabasePurchasedCharactersWithDataManager();

        _itemHeight = _shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
        Destroy(_shopItemsContainer.GetChild(0).gameObject);

        int count = _database.CharacterCount;

        for (int i = 0; i < count; i++)
        {
            var character = _database.GetCharacter(i);
            var uiItem = Instantiate(
                _itemPrefab,
                _shopItemsContainer
            ).GetComponent<CharacterItem>();

            uiItem.SetPosition(Vector2.down * i * (_itemHeight + _itemSpacing));

            uiItem.gameObject.name = "Item" + i + "-" + character.name;

            uiItem.SetName(character.name);
            uiItem.SetSprite(character.sprite);
            uiItem.SetSpeed(character.speed);
            uiItem.SetPower(character.power);
            uiItem.SetPrice(character.price);

            if (character.isPurchased)
            {
                uiItem.SetAsPurchased();
                uiItem.OnSelect(i, OnItemSelected);
            }
            else
            {
                uiItem.SetPrice(character.price);
                uiItem.OnPurchase(i, OnItemPurchased);
            }
        }

        _shopItemsContainer.GetComponent<RectTransform>().sizeDelta =
                Vector2.up * ((_itemHeight + _itemSpacing) * count + _itemSpacing);
    }

    private void MatchDatabasePurchasedCharactersWithDataManager()
    {
        int purchasedCharacterCount = DataManager.GetPurchasedCharacterIndexes().Count;

        for (int i = 0; i < purchasedCharacterCount; i++)
        {
            int index = DataManager.GetPurchasedCharacter(i);
            _database.PurchaseCharacter(index);
        }
    }

    private void ChangePlayerSkin()
    {
        var character = DataManager.GetSelectedCharacter();

        if (character.sprite != null)
        {
            _mainMenuCharacterImage.sprite = character.sprite;
            _mainMenuCharacterName.text = character.name;

            _selectedCharacterIcon.sprite = DataManager.GetSelectedCharacter().sprite;
        }
    }

    private void OnItemSelected(int index)
    {
        SelectItemUI(index);

        DataManager.SetSelectedCharacter(_database.GetCharacter(index), index);

        ChangePlayerSkin();
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

    private CharacterItem GetItemUI(int index)
    {
        return _shopItemsContainer.GetChild(index).GetComponent<CharacterItem>();
    }

    private void OnItemPurchased(int index)
    {
        var character = _database.GetCharacter(index);
        var uiItem = GetItemUI(index);

        if (DataManager.CanSpendCoins(character.price))
        {
            DataManager.SpendCoins(character.price);

            SharedUI.instance.UpdateCoinsUITexts();

            _database.PurchaseCharacter(index);

            uiItem.SetAsPurchased();
            uiItem.OnSelect(index, OnItemSelected);

            DataManager.AddPurchasedCharacterIndex(index);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    private void AddShopEvents()
    {
        buttonOpenShop.onClick.RemoveAllListeners();
        buttonCloseShop.onClick.RemoveAllListeners();

        buttonOpenShop.onClick.AddListener(OpenShop);
        buttonCloseShop.onClick.AddListener(CloseShop);
    }

    private void OpenShop()
    {
        shopUI.SetActive(true);
    }

    private void CloseShop()
    {
        shopUI.SetActive(false);
    }
}
