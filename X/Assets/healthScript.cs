using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthScript : MonoBehaviour
{
    [SerializeField] private int healthValue = 10;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().playerHealth += healthValue;
            Destroy(gameObject);
        }
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
