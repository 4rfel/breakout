using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_FimDeJogo : MonoBehaviour
{
    [SerializeField] private Text message;
    [SerializeField] private GameObject endgame_menu;
    [SerializeField] private UI_Pause ui_pause;
    [SerializeField] private UI_pontos ui_pontos;

    private int vidas;

    private bool lost = false;

    public void lose()
    {
        lost = true;
    }

    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Brick");
        if (lost)
        {
            message.text = "Perdeu Lixo!";
            endgame_menu.SetActive(true);
            ui_pause.pausado = true;
            ui_pause.end = true;
        }
        else if (objs.Length == 0)
        {
            message.text = $"Ganhou!\nTotal: {ui_pontos.end_points}";
            endgame_menu.SetActive(true);
            ui_pause.pausado = true;
            ui_pause.end = true;
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
}