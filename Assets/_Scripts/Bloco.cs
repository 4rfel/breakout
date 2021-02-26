using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    private int durability;
    private int value;

    private Color[] colors = new Color[] { new Color(0, 0, 1, 1), new Color(0, 1, 1, 1), new Color(1, 0, 1, 1), new Color(1, 0, 0, 1) };

    private UI_pontos ui_points;
    private AudioSource audioData;
    private ParticleSystem exp;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ball")
        {
            audioData.Play(0);
            durability -= 1;
            if (durability <= 0) 
            {
                Renderer rend = GetComponent<Renderer>();
                rend.enabled = false;
                ui_points.AddPoints(value);
                exp = GetComponent<ParticleSystem>();
                exp.Play();
                Destroy(gameObject, exp.main.duration);
                return;
            }
            GetComponent<SpriteRenderer>().color = colors[durability-1];
        }
    }

    public void setUIPoints(UI_pontos ui)
    {
        ui_points = ui;
    }

    public void setDurability(int dur)
    {
        durability = dur;
        GetComponent<SpriteRenderer>().color = colors[dur-1];
    }

    public void setValue(int v)
    {
        value = v;
    }

    public void setAudio(AudioSource a)
    {
        audioData = a;
    }

    public void setParticleSystem(ParticleSystem p)
    {
        //exp = p;
    }
}
