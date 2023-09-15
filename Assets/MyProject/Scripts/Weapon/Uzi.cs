using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    private int _bulletPerShot;
    private float _delay;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _delay = 0.05f;
        _bulletPerShot = 3;
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    public override void Shoot(Transform shootPoint)
    {
        _coroutine = StartCoroutine(InstantiateBullets(shootPoint));
    }

    private IEnumerator InstantiateBullets(Transform shootPoint)
    {
        for (int i = 0; i < _bulletPerShot; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);

            yield return _waitForSeconds;
        }

        StopCoroutine(_coroutine);
    }
}