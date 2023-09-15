using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _revard;

    private Player _target;

    public int Revard => _revard;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public Player GetTarget()
    {
        return _target;
    }
}
