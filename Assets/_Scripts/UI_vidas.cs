using UnityEngine;
using UnityEngine.UI;

public class UI_vidas : MonoBehaviour
{
    [SerializeField] private Text textComp;
    [SerializeField] private UI_FimDeJogo ui_fim;

    private int vidas = 3;

    void Update()
    {
        textComp.text = $"Vidas: {vidas}";
        if (vidas <= 0)
            ui_fim.lose();
    }

    public void loseLife()
    {
        vidas--;
    }

    public void setLifes(int hp)
    {
        vidas = hp;
    }

    public int getLifes()
    {
        return vidas;
    }
}