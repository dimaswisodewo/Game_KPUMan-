using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject panelMainMenu;
    public GameObject panelBantuan;
    public GameObject panelTentang;
    public GameObject panelIntro;

    void Start()
    {
        BackToMenu();
    }
    
    public void MulaiMain()
    {
        SceneManager.LoadScene(1);
    }

    public void Intro()
    {
        panelMainMenu.SetActive(false);
        panelIntro.SetActive(true);
    }

    public void Bantuan()
    {
        panelMainMenu.SetActive(false);
        panelBantuan.SetActive(true);
    }

    public void Tentang()
    {
        panelTentang.SetActive(true);
        panelMainMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        panelMainMenu.SetActive(true);
        panelBantuan.SetActive(false);
        panelTentang.SetActive(false);
        panelIntro.SetActive(false);
    }

    public void Keluar()
    {
        Application.Quit();
    }

}
