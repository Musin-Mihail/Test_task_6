using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _value;
    public Transform bulletPrefab;
    private readonly List<BulletControl> _bulletControls = new();
    public Transform enemy;
    private Ability _ability;

    private void Awake()
    {
        _ability = new Ability();
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    public Ability GetAbility()
    {
        return _ability;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f / _ability.GetSpeedValue());
            Shot();
        }
    }

    private void Shot()
    {
        StartCoroutine(GetBulletControl().Move(transform, enemy, _ability.GetSpeedValue()));
    }

    private BulletControl GetBulletControl()
    {
        foreach (var bulletControl in _bulletControls)
        {
            if (!bulletControl.Busy)
            {
                return bulletControl;
            }
        }

        return CreateBulletControl();
    }

    private BulletControl CreateBulletControl()
    {
        var bulletControl = new BulletControl(CreateBullet());
        _bulletControls.Add(bulletControl);
        return bulletControl;
    }

    private Transform CreateBullet()
    {
        var newBullet = Instantiate(bulletPrefab).gameObject;
        return newBullet.transform;
    }
}