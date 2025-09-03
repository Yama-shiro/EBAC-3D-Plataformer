using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public float maxShoot = 5f;
    public float timeToRecharge = 1f;

    private float _CurrentShoots;
    private bool _recharging = false;

    protected override IEnumerator ShootCoroutine()
    {
        /*while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBeetweenShots);
        }*/
        if (_recharging) yield break;

        while (true)
        {
            if (_CurrentShoots < maxShoot)
            {
                Shoot();
                _CurrentShoots++;
                CheckRecharge();
                yield return new WaitForSeconds(timeBeetweenShots);
            }
           
        }
    }

    private void CheckRecharge()
    {
        if(_CurrentShoots >= maxShoot)
        {
            StopShoot();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        _recharging = true;
        StartCoroutine(RechargeCoroutine());
    }

    IEnumerator RechargeCoroutine()
    {
        float time = 0;
        while (time < timeToRecharge)
        {
            time += Time.deltaTime;
            Debug.Log("Recharging: " + time);
            yield return new WaitForEndOfFrame();
        }
        _CurrentShoots = 0;
        _recharging = false;
    }
}
