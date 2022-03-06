using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{
    [Header("Layout Settings")]
    [SerializeField]
    private float _itemSpacing = 0.5f;

    private float _itemHeight;

    [Header("UI Elements")]
    [SerializeField]
    private Transform _shopItemsContainer;

    [SerializeField]
    private GameObject _itemPrefab;

    [Space(20f)]
    [SerializeField]
    private CharacterShopDatabase _database;

    [Header("Shop Events")]
    [SerializeField]
    private GameObject shopUI;
    
    [SerializeField]
    private Button buttonOpenShop;
    
    [SerializeField]
    private Button buttonCloseShop;

    void Start()
    {
        AddShopEvents();
        GenerateShopItemsUI();
    }

    private async void GenerateShopItemsUI()
    {
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

    private void OnItemSelected(int index)
    {
        Debug.Log("select " + index);
    }

    private void OnItemPurchased(int index)
    {
        Debug.Log("purchase " + index);
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
