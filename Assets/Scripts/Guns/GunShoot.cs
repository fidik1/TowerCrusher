using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private BlockChecker _blockChecker;
    public float ShootCooldown { get; private set; }
    public bool IsShooted { get; private set; }

    protected virtual void Start()
    {
        Click.instance.OnClick += Shoot;
        ShootCooldown = _gun.Data.shootCooldown;
        InvokeRepeating(nameof(Shoot), 3, 3);
    }

    public virtual void Shoot()
    {
        if (IsShooted) return;

        Bullet _bullet = Instantiate(_bulletPrefab, transform.position, _parent.rotation);
        _bullet.point = _blockChecker.GetVector();
        IsShooted = true;
        Invoke(nameof(Shooted), ShootCooldown);
    }

    private void Shooted() => IsShooted = false;

    private void OnDestroy() => Click.instance.OnClick -= Shoot;
}
