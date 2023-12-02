using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType
    {
        Straight,
        Spin
    }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawn Attributes")]
    [SerializeField]
    private SpawnerType _spawnerType;
    [SerializeField]
    private float _firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (_spawnerType == SpawnerType.Spin)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= _firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if(bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>()._speed = speed;
            spawnedBullet.GetComponent<Bullet>()._bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
