using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;

    public Action shoot;
}
