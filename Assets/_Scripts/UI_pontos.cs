using UnityEngine;
using UnityEngine.UI;

public class UI_pontos : MonoBehaviour
{
    [SerializeField] private Text textComp;
    [SerializeField] private UI_timer ui_timer;

    private int points;
    private int multi;
    public int end_points;

    public void AddPoints(int p)
    {
        points += p;
    }

    void Update()
    {
        textComp.text = $"Pontos: {points} x {ui_timer.multi}";
        end_points = points * ui_timer.multi;
    }
}
