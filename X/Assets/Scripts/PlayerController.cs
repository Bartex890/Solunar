using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public int playerHealth = 100;
    [SerializeField] private TextMeshProUGUI healthText;
    private int UpgradeGunSpeed=1;
    private int UpgradeGunMoreBalls=1;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        healthText.text = "Health: " + playerHealth.ToString();
    }
    void Update()
    {
        Move();
        healthText.text = "Health: " + playerHealth.ToString();
    }
    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        //if (moveX != 0 || moveZ != 0)
        //    anim.SetBool("Run", true);
        //else
        //    anim.SetBool("Run", false);
        Vector3 position = transform.position;
        Vector3 move = (transform.right * moveX + transform.forward * moveZ) * agent.speed;
        agent.destination = position + move;
    }
    
    public void Damage(int dmg)
    {
        playerHealth -= dmg;
        Debug.Log(playerHealth + "zosta³o ci ¿ycia");
        healthText.text = "Health: " + playerHealth.ToString();
        if (playerHealth <= 0)
        {
            Debug.Log("You DEAD");
            GetComponent<GameManager>().playerLive = false;
        }

    }

    public void SetUpgrade(string typ)
    {
        switch (typ)
        {
            case "MoreBalls": UpgradeGunMoreBalls++; break;
            case "Speed": UpgradeGunSpeed++; break;

        }
        ListOfGuns.Instance.SetUpgradeForAllGuns(UpgradeGunMoreBalls, UpgradeGunSpeed);
    }
    private void Upgrade()
    {

    }
}
