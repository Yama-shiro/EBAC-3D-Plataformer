using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    [Header("Armas disponíveis")]
    public List<GunBase> gunPrefabs; // Lista de prefabs de armas
    public Transform gunPosition;    // Onde a arma será instanciada

    private GunBase _currentGun;     // Referência da arma equipada
    private int _currentGunIndex = 0; // Índice da arma equipada

    private void Start()
    {
        // Equipa a primeira arma
        if (gunPrefabs.Count > 0)
        {
            EquipGun(0);
        }
    }

    private void Update()
    {
        // Troca de armas (1 e 2)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gunPrefabs.Count > 1)
        {
            EquipGun(1);
        }

        // --- Mantive seu esquema original de tiro ---
        if (_currentGun != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Pressionou botão de tiro
            {
                _currentGun.StartShoot();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0)) // Soltou botão de tiro
            {
                _currentGun.StopShoot();
            }
        }
    }

    private void EquipGun(int index)
    {
        if (index < 0 || index >= gunPrefabs.Count) return;

        // Destroi a arma antiga
        if (_currentGun != null)
        {
            Destroy(_currentGun.gameObject);
        }

        // Instancia a nova arma no lugar certo
        _currentGun = Instantiate(gunPrefabs[index], gunPosition.position, gunPosition.rotation, gunPosition);
        _currentGunIndex = index;
    }
}


