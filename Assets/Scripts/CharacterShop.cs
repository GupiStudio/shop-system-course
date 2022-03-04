using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{
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
