using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class World : MonoBehaviour
{
    public static World Instance;
    public GunsController GunsController { get; private set; }
    public GunsMerge GunsMerge { get; private set; }
    public LapsController LapsController { get; private set; }
    [field: SerializeField] public BonusManager BonusManager { get; private set; }

    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _parentGuns;
    [SerializeField] private GunData[] _gunData;

    private void Awake()
    {
        if (Instance == null ) Instance = this;
        GunsController = new(_camera, _parentGuns);
        GunsMerge = new(_gunData);
        LapsController = new();
    }

    private void Start()
    {
        ExecuteWithDelay(.5f, LapsController.BonusLapExecuted);
    }

    public static void ExecuteWithDelay(float time, Action callback)
    {
        DOTween.To(() => 0, x => { }, 1, time).OnComplete(() => callback()).SetLink(Instance.gameObject);
    }
}
