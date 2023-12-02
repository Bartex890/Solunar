using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfGuns : MonoBehaviour
{
    [SerializeField]
    private List<ProjectileGun> guns;

    private static ListOfGuns _instance;
    public static ListOfGuns Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("ListOfGuns.Instance is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void SetUpgradeForAllGuns(int UpgradeGunMoreBalls, int UpgradeGunSpeed)
    {
        foreach(ProjectileGun projectileGun in guns)
        {
            projectileGun.timeBetweenShooting = projectileGun.timeBetweenShootingBase / UpgradeGunSpeed;
            if(UpgradeGunMoreBalls > 0)
            {
                projectileGun.gameObject.SetActive(true);
                UpgradeGunMoreBalls--;
            }
        }
    }
}
