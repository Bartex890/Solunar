using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _bulletLife;
    public float _rotation;
    public float _speed;

    private Vector3 _spawnPoint;
    private float _timer = 0f;

    private void Start()
    {
        _spawnPoint = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    private void Update()
    {
        if (_timer > _bulletLife) Destroy(this.gameObject);
        _timer += Time.deltaTime;
        transform.position = Movement(_timer);
    }

    private Vector3 Movement(float timer)
    {
        float x = timer * _speed * transform.right.x;
        float y = timer * _speed * transform.right.y;
        float z = timer * _speed * transform.right.z;
        return new Vector3(x + _spawnPoint.x, y + _spawnPoint.y, z + _spawnPoint.z);
    }
}
