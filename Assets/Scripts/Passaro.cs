using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{
    private bool flying;
    private Rigidbody2D passaro;

    [SerializeField] private float velocidade;
    [SerializeField] private GameObject gameOver;


    // Start is called before the first frame update
    void Start()
    {
        flying = false;
        passaro = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flying = true;
        }
    }

    void FixedUpdate()
    {
        if (flying)
        {
            passaro.velocity = Vector2.up * velocidade;
            flying = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
}
