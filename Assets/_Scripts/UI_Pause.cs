using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Pause : MonoBehaviour
{
    public bool pausado = false;
    public bool end = false;

    [SerializeField] private GameObject pause_menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && end == false)
        {
            pausado = !pausado;
            pause_menu.SetActive(pausado);
        }
    }

    public void Retornar()
    {
        pausado = false;
        pause_menu.SetActive(pausado);
    }

    public void Home()
    {
        pausado = false;
        SceneManager.LoadScene("Menu");
    }
}