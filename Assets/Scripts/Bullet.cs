using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private Rigidbody _rigidbody;
    private int _damage;
    public void Init(Vector3 velocity, int damage = 0)
    {
        _damage = damage;
        _rigidbody.velocity = velocity;
        StartCoroutine(DelayDestroy());
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out EnemyCharacter enemy))
        {
            enemy.AppllyDamage(_damage);
        }

        Destroy();
    }
}
