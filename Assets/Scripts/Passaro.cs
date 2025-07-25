using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{
    private bool flying;
    private Rigidbody2D passaroRB;
    private SpriteRenderer passaroSR;
    [SerializeField] private Sprite passaroCima, passaroBaixo, passaroMeio;

    [SerializeField] private float velocidade;
    [SerializeField] private GameObject GameOver;


    // Start is called before the first frame update
    void Start()
    {
        flying = false;
        passaroRB = GetComponent<Rigidbody2D>();
        passaroSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flying = true;
        }

        if (passaroRB.velocity.y > 0)
        {
            passaroSR.sprite = passaroCima;
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else if (passaroRB.velocity.y < 0)
        {
            passaroSR.sprite = passaroBaixo;
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
        else
        {
            passaroSR.sprite = passaroMeio;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        if (flying)
        {
            passaroRB.velocity = Vector2.up * velocidade;
            flying = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0f;
        GameOver.SetActive(true);
    }
}
