using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
	private float vel = -8;
	private float r;

	private Rigidbody2D rb2D;

	public bool flag_start = false;
	private bool reestart = false;
	private bool pausado;

	private Vector3 direcao;
	private Vector3 reestart_dir;

	[SerializeField] private UI_Pause ui_pause;
	[SerializeField] private UI_vidas ui_vidas;

	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();

		r = transform.lossyScale[1]/2;
	}

	void Update()
	{
		pausado = ui_pause.pausado;

		if (pausado == true)
        {
			if(reestart == false)
            {
				reestart_dir = rb2D.velocity;
				rb2D.velocity = new Vector3(0, 0);
				reestart = true;
            }
			return;
        }
		if(reestart == true && pausado == false)
        {
			rb2D.velocity = reestart_dir;
			reestart = false;
		}

		if (flag_start == false)
		{
			float inputX = Input.GetAxis("Horizontal");

			transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * 10;

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Vector3 dir = new Vector3(0, 1).normalized;
				rb2D.velocity = dir * vel;

				flag_start = true;
			}
			return;
		}

		Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

		if(posicaoVP.x < 0 || posicaoVP.x > 1)
		{
			rb2D.velocity = new Vector3(-rb2D.velocity.x, rb2D.velocity.y);
			if(posicaoVP.x < 0) {
				transform.position += new Vector3(r + 0.01f, 0);
			}
			else {
				transform.position -= new Vector3(r + 0.01f, 0);
			}
		}
		if(posicaoVP.y > 1)
		{
			rb2D.velocity = new Vector3(rb2D.velocity.x, -rb2D.velocity.y);
			transform.position = new Vector3(transform.position[0], 4.8f);
		}
		if(posicaoVP.y < 0)
		{
			Reset();
		}
	}

	private void Reset()
	{
		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		rb2D.velocity = new Vector3(0.0f, 0.0f);
		transform.position = playerPosition + new Vector3(0, 1f, 0);

		flag_start = false;

		ui_vidas.loseLife();
	}
}
