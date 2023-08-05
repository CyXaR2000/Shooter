using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus.Schema;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyCharacter _character;
    private List<float> _receiveTimeinterval = new List<float> { 0, 0, 0, 0, 0 };
    private float AverageInterval
    {
        get
        {
            int receiveTimeIntervalCount = _receiveTimeinterval.Count;
            float summ = 0;
            for (int i = 0; i < _receiveTimeinterval.Count; i++)
            {
                summ += _receiveTimeinterval[i];
            }

            return summ / receiveTimeIntervalCount;
        }
    }
    private float _lastReceiveTime = 0f;
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
        // _character.SetSpeed(player.speed);
        player.OnChange += OnChange;
    }

    public void Destroy()
    {
        _player.OnChange -= OnChange;
        Destroy(gameObject);
    }
    private void SaveReceiveTime()
    {
        float interval = Time.time - _lastReceiveTime;
        _lastReceiveTime = Time.time;
        _receiveTimeinterval.Add(interval);
        _receiveTimeinterval.Remove(0);
    }
    internal void OnChange(List<DataChange> chsnges)
    {
        Vector3 position = _character.transform.position;
        Vector3 velocity = Vector3.zero;

        foreach (var dataChange in chsnges)
        {
            switch (dataChange.Field)
            {
                case "pX":
                    position.x = (float)dataChange.Value;
                    break;
                case "pY":
                    position.y = (float)dataChange.Value;
                    break;
                case "pZ":
                    position.z = (float)dataChange.Value;
                    break;
                case "vX":
                    velocity.x = (float)dataChange.Value;
                    break;
                case "vY":
                    velocity.y = (float)dataChange.Value;
                    break;
                case "vZ":
                    velocity.z = (float)dataChange.Value;
                    break;
                default:
                    Debug.LogWarning("Не обрабатывается " + dataChange.Field);
                    break;
            }

        }

        // transform.position = position;
        _character.SetMovement(position, velocity, AverageInterval);

    }
}
