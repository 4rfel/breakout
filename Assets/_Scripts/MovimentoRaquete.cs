using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete: MonoBehaviour
{
    private float velocidade = 10;

    private bool pausado;

    [SerializeField] private UI_Pause ui_p;

    void Update()
    {
        pausado = ui_p.pausado;

        if (pausado == true) return;

        float inputX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        rot_z = Mathf.Clamp(rot_z, 45, 135);
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
