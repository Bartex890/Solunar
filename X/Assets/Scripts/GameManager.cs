using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject boss;
    public bool playerLive = true;
    public GameObject endPanel;
    public GameObject cutscenkaPoZerowejFali;
    public GameObject cutscenkaPoZerowejDwaFali;
    public GameObject cutscenkaPoPierwszejFali;
    public GameObject cutscenkaPoDrugiejFali;
    public GameObject cutscenkaPoTrzeciejFali;
    public TextMeshProUGUI endText;
    // Start is called before the first frame update
    public float timer = 0f;
    private bool endTime=false;
    public static bool winBoss = false;
    void CheckWin()
    {
        //Timer?

        if (playerLive == false)
        {
            //endText.text = "Nie zyjesz!!";
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            endPanel.SetActive(true);
        }else if (/*endTime ||*/ winBoss)
        {
            Time.timeScale = 0;
            cutscenkaPoTrzeciejFali.SetActive(true);
        }
    }



    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cutscenkaPoZerowejFali.activeSelf)
        {
            cutscenkaPoZerowejFali.SetActive(false);
            cutscenkaPoZerowejDwaFali.SetActive(true);
        }else if (Input.GetKeyDown(KeyCode.Space) && cutscenkaPoZerowejDwaFali.activeSelf)
        {
            cutscenkaPoZerowejDwaFali.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cutscenkaPoPierwszejFali.activeSelf)
        {
            cutscenkaPoPierwszejFali.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && cutscenkaPoDrugiejFali.activeSelf)
        {
            cutscenkaPoDrugiejFali.SetActive(false);
            Time.timeScale = 1;
        }else if (Input.GetKeyDown(KeyCode.Space) && (cutscenkaPoTrzeciejFali.activeSelf || endPanel.activeSelf)){
            SceneManager.LoadScene("Menu");
        }



        timer += Time.deltaTime;
        if(timer > 10f && EnemyController.fala <2)
        {
            Time.timeScale = 0;
            EnemyController.fala = 2;
            cutscenkaPoPierwszejFali.SetActive(true);
        }else if (timer > 20f && EnemyController.fala < 3)
        {
            Time.timeScale = 0;
            EnemyController.fala = 3;
            boss.SetActive(true);
            cutscenkaPoDrugiejFali.SetActive(true);
        }
        else if (timer > 30f)
        {
            endTime = true;
        }
        CheckWin();

    }
}
