using UnityEngine;
using System;

public enum TypeGun
{
    GunDefault,
    GunFirst,
    GunSecond
}

public class Gun : MonoBehaviour
{
    [field: SerializeField] public GunData Data { get; private set; }
    public GameObject prefabParticle;
    public GunMovement gunMovement;
    public TypeGun typeGun;

    private void Start() => typeGun = Data.typeGun;
}
