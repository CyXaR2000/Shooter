using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus.Schema;

public class EnemyController : MonoBehaviour
{
    internal void OnChange(List<DataChange> chsnges)
    {
        Vector3 position = transform.position;
        foreach (var dataChange in chsnges)
        {
            switch (dataChange.Field)
            {
                case "x":
                    position.x = (float)dataChange.Value;
                    break;
                case "y":
                    position.z = (float)dataChange.Value;
                    break;
                default:
                    Debug.LogWarning("Не обрабатывается " + dataChange.Field);
                    break;
            }

        }

        transform.position = position;

    }
}
