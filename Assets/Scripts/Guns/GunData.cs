using UnityEngine;

[CreateAssetMenu(menuName = "Gun/Gun", fileName = "Gun")]
public class GunData : ScriptableObject
{
    public TypeGunEnum typeGun;
    public GameObject prefabGun;
    public float shootCooldown;
}
