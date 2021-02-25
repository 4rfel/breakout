using UnityEngine;
using UnityEngine.UI;

public class UI_timer : MonoBehaviour
{
    [SerializeField] private Text textComp;
    [SerializeField] private UI_Pause ui_pause;
    [SerializeField] private MovimentoBola bola;

    private float timer = 0f;

    private bool f = true;

    public int multi = 4;

    void Update()
    {
        textComp.text = $"{timer.ToString("F3")} s";

        if (ui_pause.pausado == true || bola.flag_start == false) return;

        timer += Time.deltaTime;

        if ((int)timer % 60 == 0 && multi > 1 && f == false)
        {
            multi--;
            f = true;
        }
        else if ((int)timer % 60 >= 1) f = false;
    }
}
