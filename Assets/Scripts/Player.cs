using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _value;
    public Transform bulletPrefab;
    private readonly List<BulletControl> _bulletControls = new();
    private Transform _enemyTarget;
    public List<Transform> enemies;
    private Ability _ability;

    private void Awake()
    {
        _ability = new Ability();
    }

    private void Start()
    {
        StartCoroutine(Move());
        var findObjectsOfType = FindObjectsOfType<Enemy>();
        foreach (var enemy in findObjectsOfType)
        {
            enemies.Add(enemy.gameObject.transform);
        }
    }

    public Ability GetAbility()
    {
        return _ability;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (_enemyTarget && _enemyTarget.gameObject.activeSelf)
            {
                Shot();
                yield return new WaitForSeconds(2.0f / _ability.GetSpeedValue());
            }
            else
            {
                enemies = enemies.OrderBy(enemy => Vector3.Distance(enemy.position, transform.position)).ToList();
                foreach (var enemy in enemies)
                {
                    if (enemy.gameObject.activeSelf && Vector3.Distance(transform.position, enemy.gameObject.transform.position) < 20)
                    {
                        _enemyTarget = enemy;
                        break;
                    }
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private void Shot()
    {
        StartCoroutine(GetBulletControl().Move(transform, _enemyTarget, _ability.GetSpeedValue()));
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