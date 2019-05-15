using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    #region Singleton 

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;        
    }

    #endregion

    public GameObject player;
    public PlayerController playerController;
    public Transform playerTransform;
    public string scene;

    public Rigidbody playerRB;

    public KPUBuilding kpuBuilding;

    public GameObject panelMenang;
    public GameObject panelKalah;
    public TextMeshProUGUI skorText;
    public TextMeshProUGUI boxTarget;
    public TextMeshProUGUI currentBox;
    public TextMeshProUGUI skorMenang;
    private float timerSkor;
    private float skor;
    private bool isWin = false;

    public void Die()
    {
        panelKalah.SetActive(true);
        Time.timeScale = 0;
        if (Input.GetKey("r"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(scene);
        }
    }

    public void Win()
    {
        panelMenang.SetActive(true);
        skorMenang.text = skor.ToString();
        Time.timeScale = 0;
        if (Input.GetKey(KeyCode.Return))
        {

            if (kpuBuilding.isWin == 2)
            {
                SceneManager.LoadScene(2);
                Time.timeScale = 1;
            }
            if (kpuBuilding.isWin == 3)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        playerController = FindObjectOfType<PlayerController>();
        playerTransform = playerController.transform;
        playerRB = playerController.GetComponent<Rigidbody>();

        kpuBuilding = FindObjectOfType<KPUBuilding>();
        panelMenang.SetActive(false);
        panelKalah.SetActive(false);
        isWin = false;
        
    }

    void Update()
    {
        if (playerTransform.position.y < -15)
        {
            Die();
        }

        timerSkor += Time.deltaTime;

        if (timerSkor > 1f && kpuBuilding.winning == false)
        {
            skor += 1;
            skorText.text = skor.ToString();
            timerSkor = 0;
        }

        if (kpuBuilding.winning == true)
        {
            isWin = true;
        }

        boxTarget.text = kpuBuilding.isWin.ToString();
        currentBox.text = kpuBuilding.currentBox.ToString();

    }

}
