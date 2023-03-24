using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health;

    public Enemy()
    {
        _health = 50;
    }

    void CheckHealth(int damage)
    {
        if (_health > damage)
        {
            _health -= damage;
        }
        else
        {
            gameObject.SetActive(false);
            EventManager.DeadEnemy?.Invoke(transform.position);
        }
    }
}