using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    private int durability;
    private int value;

    private Color[] colors = new Color[] { new Color(0, 0, 1, 1), new Color(0, 1, 1, 1), new Color(1, 0, 1, 1), new Color(1, 0, 0, 1) };

    [SerializeField] private UI_pontos ui_points;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ball") 
        { 
            durability -= 1;
            if (durability <= 0) 
            {
                ui_points.AddPoints(value);
                ParticleSystem exp = GetComponent<ParticleSystem>();
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
 }
