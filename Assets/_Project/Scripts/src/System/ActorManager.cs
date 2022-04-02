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

    [SerializeField] private UserManager _userManager;
    [SerializeField] private ShopManager _shopManager;
    
    private void Awake()
    {
        Construct();
        Initialize();
    }
    
    private void Construct()
    {
        //
    }
    
    private void Initialize()
    {
        LoadData();
    }

    private void LoadData()
    {
        var currentIndex = _userManager.GetCurrentActorIndex();
        
        var actorList = _shopManager.GetActorsList();

        var currentActor = actorList[currentIndex];
        
        _controller.SetSpeed(currentActor.Speed);
        
        _ui.SetName(currentActor.Name);
        _ui.SetImage(_iconPack.Icons[currentIndex]);
    }
}
