using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    [SerializeField] private UI_pontos ui_points;
    [SerializeField] private GameObject Bloco;


    [SerializeField] private AudioSource audioData;
    [SerializeField] private ParticleSystem exp;

    void Start()
    {
        int n = 10;
        Debug.Log(n + " " + Bloco.GetComponent<SpriteRenderer>().sprite.rect.width);
        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                Vector3 posicao = new Vector3(-7 + 1.55f * i, 4 - 0.55f * j);

                GameObject Brick = Instantiate(Bloco, posicao, Quaternion.identity, transform);
                Brick.GetComponent<Bloco>().setDurability(4 - j);
                Brick.GetComponent<Bloco>().setValue(4 - j);
                Brick.GetComponent<Bloco>().setUIPoints(ui_points);
                Brick.GetComponent<Bloco>().setAudio(audioData);
                Brick.GetComponent<Bloco>().setParticleSystem(exp);
            }
        }
    }
}
