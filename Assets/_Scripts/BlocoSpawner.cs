using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    [SerializeField] private UI_pontos ui_points;
    [SerializeField] private GameObject Bloco;

    void Start()
    {
        for(int i = 0; i < 11; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                Vector3 posicao = new Vector3(-8 + 1.55f * i, 4 - 0.55f * j);

                GameObject Brick = Instantiate(Bloco, posicao, Quaternion.identity, transform);
                Brick.GetComponent<Bloco>().setDurability(4 - j);
                Brick.GetComponent<Bloco>().setValue(4 - j);
                Brick.GetComponent<Bloco>().setUIPoints(ui_points);
            }
        }
    }
}
