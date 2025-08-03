using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Passaro : MonoBehaviour
{
    private bool flying;
    private Rigidbody2D passaroRB;

    [SerializeField] private float velocidade;

    private int Score;


    // Start is called before the first frame update
    void Start()
    {
        flying = false;
        passaroRB = GetComponent<Rigidbody2D>();

        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            flying = true;
        }

        float rotacaoPassaro = 0f;
        if (passaroRB.velocity.y > 4)
        {
            rotacaoPassaro = 30f;
        }
        else if (passaroRB.velocity.y < -4)
        {
            rotacaoPassaro = -30f;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotacaoPassaro), Time.deltaTime * 10f);
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
        GameController.instance.GameOver();
        Score = 0;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cano"))
        {
            Score += 1;
            Debug.Log("score: " + Score);
        }
    }
}
