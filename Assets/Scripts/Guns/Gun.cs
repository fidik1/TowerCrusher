using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    void Shoot();
}

public abstract class Gun : MonoBehaviour, IGun
{
    [SerializeField] private GunStats _stats;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private BlockChecker _blockChecker;

    public float ShootCooldown { get; private set; }
    public bool IsShooted { get; private set; }

    private void Start()
    {
        Click.instance.OnClick += Shoot;
        ShootCooldown = _stats.shootCooldown;

        InvokeRepeating(nameof(Shoot), 3, 3);
    }

    public virtual void Shoot()
    {
        if (IsShooted) return;

        GameObject _bullet = Instantiate(_bulletPrefab, transform.position, _parent.rotation);
        _bullet.GetComponent<Bullet>().point = _blockChecker.GetVector();
        IsShooted = true;
        Invoke(nameof(Shooted), ShootCooldown);
    }

    private void Shooted()
    {
        IsShooted = false;
    }
}
