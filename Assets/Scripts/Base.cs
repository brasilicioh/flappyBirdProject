using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private float velocidade = 6f;
    private float larguraBase;

    // Start is called before the first frame update
    void Start()
    {
        larguraBase = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x -= velocidade * Time.deltaTime;
        transform.position = position;

        if (position.x <= -larguraBase)
        {
            position.x += larguraBase * 2f;
            transform.position = position;
        }
    }
}
