using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            // EventManager.DeadEnemy?.Invoke(other.transform.position);
        }
    }
}