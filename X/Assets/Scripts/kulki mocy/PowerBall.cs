using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBall : MonoBehaviour
{
    public enum TypePowerBall
    {
        Speed,
        MoreBalls
    }
    [SerializeField]
    private TypePowerBall typePowerBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (typePowerBall)
            {
                case TypePowerBall.MoreBalls:
                    other.gameObject.GetComponent<PlayerController>().SetUpgrade("MoreBalls");
                    break;
                case TypePowerBall.Speed:
                    other.gameObject.GetComponent<PlayerController>().SetUpgrade("Speed");
                    break;
            }
            Destroy(gameObject);
            
        }
    }

}
