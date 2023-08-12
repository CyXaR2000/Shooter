using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _head;
    public Vector3 _targetPosition { get; private set; } = Vector3.zero;
    private float _velocityMagnitude = 0;

    private void Start()
    {
        _targetPosition = transform.position;
    }
    private void Update()
    {
        if (_velocityMagnitude > 0.1f)
        {
            float maxDistance = _velocityMagnitude * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, maxDistance);
        }
        else
        {
            transform.position = _targetPosition;
        }

    }

    public void SetSpeed(float value) => speed = value;
    public void SetMaxHP(int value)
    {
        maxHealth = value;
        _health.SendMax(value);
        _health.SetCurrent(value);
    }
    public void SetMovement(in Vector3 position, in Vector3 velocity, in float averageInterval)
    {
        _targetPosition = position + (velocity * averageInterval);
        _velocityMagnitude = velocity.magnitude;

        this._velocity = velocity;
    }

    public void AppllyDamage(int damage)
    {
        _health.AppllyDamage(damage);
    }
    public void SetRotateX(float value)
    {
        _head.localEulerAngles = new Vector3(value, 0, 0);
    }

    public void SetRotateY(float value)
    {
        transform.localEulerAngles = new Vector3(0, value, 0);
    }

    // public void SetPosition(Vector3 position)
    // {
    //     transform.position = position;
    // }
}
