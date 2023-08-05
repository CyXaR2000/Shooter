using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [field: SerializeField] public float _speed { get; protected set; } = 2f;
    public Vector3 _velocity { get; protected set; }
}