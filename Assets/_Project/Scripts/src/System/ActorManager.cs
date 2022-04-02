using System;
using System.Collections;
using System.Collections.Generic;
using Gupi2D.TopDownGame;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    [SerializeField] private IconPackSO _iconPack;
    [SerializeField] private ActorController _controller;
    [SerializeField] private GameActorUI _ui;

    [SerializeField] private GameObject _userSavedDataGameObject;
    [SerializeField] private GameObject _shopDatabaseGameObject;
    
    private IUserSavedData _userSavedData;
    private IShopDatabase _shopDatabase;
    
    private void Awake()
    {
        Construct();
        Initialize();
    }
    
    private void Construct()
    {
        _userSavedData ??= _userSavedDataGameObject.GetComponent<IUserSavedData>();
        _shopDatabase ??= _shopDatabaseGameObject.GetComponent<IShopDatabase>();
    }
    
    private void Initialize()
    {
        // LoadData();
    }

    private void LoadData()
    {
        var currentIndex = _userSavedData.UserData.CurrentActorIndex;
        var currentActor = _shopDatabase.ActorsInSale[currentIndex];
        
        _controller.SetSpeed(currentActor.Speed);
        
        _ui.SetName(currentActor.Name);
        _ui.SetImage(_iconPack.Icons[currentIndex]);
    }
}
