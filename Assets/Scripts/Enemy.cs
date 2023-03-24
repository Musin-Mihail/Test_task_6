using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health;

    public Enemy()
    {
        _health = 20;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            var damage = EventManager.Hit?.Invoke();
            if (damage != null) CheckHealth(damage.Value);
        }
    }
}