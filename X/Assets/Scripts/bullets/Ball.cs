using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public int damage;
    private float timer;
    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 5)
        {
            Debug.Log("Ala ma kota");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().Damage(damage);
            Destroy(gameObject);
        }
        //if (other.gameObject.tag != "Player") 
            //Destroy(gameObject);
    }
}
