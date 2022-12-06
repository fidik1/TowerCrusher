using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _barrel;
    [SerializeField] private BlockChecker _blockChecker;
    public float ShootCooldown { get; private set; }
    public bool IsShooted { get; private set; } = true;

    private void Start()
    {
        Click.instance.OnClick += Shoot;
        ShootCooldown = _gun.Data.shootCooldown;
        Invoke(nameof(ShootTrue), 0.5f);
        InvokeRepeating(nameof(Shoot), 3, 3);
    }

    private void ShootTrue() => IsShooted = false;

    private void Shoot()
    {
        if (IsShooted) return;

        Bullet _bullet = Instantiate(_bulletPrefab, _firePoint.transform.position, _parent.rotation);
        _bullet.point = _blockChecker.GetVector();
        IsShooted = true;
        Invoke(nameof(Shooted), ShootCooldown);
        ShootAnim();
    }

    private void ShootAnim()
    {
        _barrel.DOLocalMoveZ(0.6f, 0.15f).SetLink(_barrel.gameObject);
        Invoke(nameof(DoMove), 0.151f);
    }

    private void DoMove() => _barrel.DOLocalMoveZ(0.9f, 0.15f).SetLink(_barrel.gameObject);

    private void Shooted() => IsShooted = false;

    private void OnDestroy() => Click.instance.OnClick -= Shoot;
}
