using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private const string Grounded = "Grounded";
    private const string Speed = "Speed";

    [SerializeField] private Animator _animator;
    [SerializeField] private CheckFly _checkFly;
    [SerializeField] private Character _character;
    [SerializeField] private float _maxSpeed = 6f;

    private void Update()
    {
        Vector3 localVelocity = _character.transform.InverseTransformVector(_character._velocity);
        float speed = localVelocity.magnitude / _maxSpeed;
        float sign = Mathf.Sign(localVelocity.z);

        _animator.SetFloat(Speed, speed * sign);
        _animator.SetBool(Grounded, _checkFly.IsFly == false);
    }
}
