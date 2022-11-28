using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class World : MonoBehaviour
{
    public static World Instance;
    public GunsController gunsController;
    public BonusManager bonusManager;

    [SerializeField] private Transform _parentGuns;
    [SerializeField] private GunData[] _gunData;

    private void Awake()
    {
        Instance = this;
        gunsController = new(_parentGuns, _gunData);
    }

    private void Start()
    {
        ExecuteWithDelay(.5f, gunsController.BonusLapExecuted);
    }

    public static void ExecuteWithDelay(float time, Action callback)
    {
        DOTween.To(() => 0, x => { }, 1, time).OnComplete(() => callback()).SetLink(Instance.gameObject);
    }
}
