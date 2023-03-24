using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _value;
    public Transform bulletPrefab;
    private readonly List<BulletControl> _bulletControls = new();
    public Transform enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    void Shot()
    {
        StartCoroutine(GetBulletControl().Move(transform, enemy));
    }

    BulletControl GetBulletControl()
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

    BulletControl CreateBulletControl()
    {
        var bulletControl = new BulletControl(CreateBullet());
        _bulletControls.Add(bulletControl);
        return bulletControl;
    }

    Transform CreateBullet()
    {
        var newBullet = Instantiate(bulletPrefab).gameObject;
        return newBullet.transform;
    }
}