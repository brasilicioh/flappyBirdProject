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
    private bool starting, perdeu;
    private Vector2 passaroStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        Sprite[] fundos = { fundo1, fundo2 };
        passaroStartPosition = passaro.transform.position;
        starting = true;
        perdeu = false;
        InvokeRepeating("SpawnCanos", 0f, intervaloCano);
        background.sprite = fundos[Random.Range(0, fundos.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && starting)
        {
            menu.SetActive(false);
            passaro.SetActive(true);
            bases.SetActive(true);
            starting = false;

            Time.timeScale = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && perdeu)
        {
            menu.SetActive(true);
            gameOver.SetActive(false);
            bases.SetActive(false);
            passaro.SetActive(false);
            starting = true;
            perdeu = false;

            foreach (GameObject cloneCano in GameObject.FindGameObjectsWithTag("Cano"))
            {
                Destroy(cloneCano);
            }
            passaro.transform.position = passaroStartPosition;
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
        starting = false;
        perdeu = true;
    }
}
