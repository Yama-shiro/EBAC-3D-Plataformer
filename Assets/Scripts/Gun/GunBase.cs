using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBeetweenShots = 0.3f;

    public Coroutine _currentCoroutine;



 protected virtual IEnumerator ShootCoroutine()
 
    {
       while (true)
       {
          Shoot();
          yield return new WaitForSeconds(timeBeetweenShots);
       }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
    }

    public void StartShoot()
    {
        StopShoot();
        _currentCoroutine = StartCoroutine(ShootCoroutine());
    }

    public void StopShoot()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
}

