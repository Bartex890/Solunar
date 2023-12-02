using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    [SerializeField] private int enemyDamage;
    [SerializeField] private float enemyScale;
    [SerializeField] private int enemyHealth;
    [SerializeField] private float enemySpeed;
    [SerializeField] GameObject kulaZycia;
    [SerializeField] GameObject kulaMocy;
    [SerializeField] GameObject kulaPredkosci;
    public static int fala = 1;
    public bool isBoss;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (!isBoss)
        EnemyGenerator();
    }

    void Move()
    {
        agent.destination = player.gameObject.transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Damage(enemyDamage);
            if (!isBoss)
            Destroy(gameObject);
        }
    }

    void EnemyGenerator()
    {
        int rand = Random.Range(1, 100);
        if (fala == 1)
        {

            if (rand <= 80)
            {
                enemyDamage = 20;
                enemyScale = 2;
                enemyHealth = 10;
                enemySpeed = 2.5f;
            }
            else if (rand > 80)
            {
                enemyDamage = 10;
                enemyScale = 1;
                enemyHealth = 5;
                enemySpeed = 3f;
            }
        }
        else if (fala == 2)
        {
            Debug.Log("Start drugiej fali");
            if (rand >= 85)
            {
                enemyDamage = 30;
                enemyScale = 3;
                enemyHealth = 30;
                enemySpeed = 2f;
            }
            else if (rand < 85 && rand >= 50)
            {
                enemyDamage = 20;
                enemyScale = 2;
                enemyHealth = 10;
                enemySpeed = 2.5f;
            }
            else if (rand < 50)
            {
                enemyDamage = 10;
                enemyScale = 1;
                enemyHealth = 10;
                enemySpeed = 3.5f;
            }


        }
        else if (fala == 3)
        {
            Debug.Log("Start trzeciej fali");
            if (rand >= 85)
            {
                enemyDamage = 40;
                enemyScale = 3;
                enemyHealth = 30;
                enemySpeed = 2f;
            }
            else if (rand < 85 && rand >= 50)
            {
                enemyDamage = 30;
                enemyScale = 2;
                enemyHealth = 10;
                enemySpeed = 2.5f;
            }
            else if (rand < 50 && rand >= 25)
            {
                enemyDamage = 20;
                enemyScale = 1;
                enemyHealth = 10;
                enemySpeed = 3.5f;
            }
            else if (rand < 25)
            {
                enemyDamage = 10;
                enemyScale = 0.7f;
                enemyHealth = 10;
                enemySpeed = 4f;
            }

        }
            transform.localScale *= enemyScale;
            agent.speed = enemySpeed;
    }
    


    public void Damage(int dmg)
    {
        enemyHealth -= dmg;
        if (enemyHealth <= 0)
        {
            SpawnBalls();
            if (isBoss)
                GameManager.winBoss = true;
            Destroy(gameObject);
        }

    }
    void SpawnBalls()
    {
        int losujkule = Random.Range(1, 100);
        Vector3 pos = transform.position;
        if (losujkule > 0 && losujkule < 10)
        {
            Instantiate(kulaZycia, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        }
        else if(losujkule >= 10 && losujkule < 15)
        {
            Instantiate(kulaMocy, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        }
        else if (losujkule >= 15 && losujkule < 20)
        {
            Instantiate(kulaPredkosci, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        }
    }
}
