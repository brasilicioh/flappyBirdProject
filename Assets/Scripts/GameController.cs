using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private GameObject menu, passaro, bases, canos, source, gameOver;
    [SerializeField] private float intervaloCano;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Sprite fundo1, fundo2;
    private bool starting;

    // Start is called before the first frame update
    void Start()
    {
        Sprite[] fundos = { fundo1, fundo2 };
        starting = true;
        InvokeRepeating("SpawnCanos", 0f, intervaloCano);
        background.sprite = fundos[Random.Range(0, fundos.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && starting)
        {
            Destroy(menu);
            passaro.SetActive(true);
            bases.SetActive(true);
            starting = false;
        }
    }

    void SpawnCanos()
    {
        if (!starting)
        {
            Vector2 positionSource = source.transform.position;
            positionSource.y = Random.Range(-2.5f, 2.5f);
            // metodo que instancia o prefab; o objeto, a posicao, a rotacao padrao do negocio
            Instantiate(canos, positionSource, Quaternion.identity);
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
}
