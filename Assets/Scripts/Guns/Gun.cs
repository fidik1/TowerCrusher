using UnityEngine;
using System;

public enum TypeGunEnum
{
    GunDefault,
    GunFirst,
    GunSecond
}

public class Gun : MonoBehaviour
{
    [field: SerializeField] public GunData Data { get; private set; }
    [field: SerializeField] public GameObject PrefabParticle { get; private set; }
    [field: SerializeField] public GunMovement GunMovement { get; private set; }
    [field: SerializeField] public TypeGunEnum TypeGun { get; private set; }

    private void Start() => TypeGun = Data.typeGun;
}
