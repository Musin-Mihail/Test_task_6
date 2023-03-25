using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health;
    private int _maxHealth;
    public RectTransform healthBar;

    public Enemy()
    {
        _health = 20;
        _maxHealth = 20;
    }

    private IEnumerator Hit(int damage)
    {
        _health -= damage;
        float width = (float)_health / _maxHealth * 1.5f;
        float startWidth = healthBar.sizeDelta.x;
        while (healthBar.sizeDelta.x > width)
        {
            yield return new WaitForSeconds(0.01f);
            startWidth -= 0.04f;
            healthBar.sizeDelta = new Vector2(startWidth, 0.3f);
        }

        if (_health <= 0)
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
            if (damage != null) StartCoroutine(Hit(damage.Value));
        }
    }
}