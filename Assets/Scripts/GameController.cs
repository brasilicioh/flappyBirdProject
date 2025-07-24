using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject message, duck, canos, source;
    private bool starting;

    // Start is called before the first frame update
    void Start()
    {
        starting = true;
        InvokeRepeating("SpawnCanos", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && starting)
        {
            Destroy(message);
            duck.SetActive(true);
            starting = false;
        }
    }

    void SpawnCanos()
    {
        if (!starting)
        {
            // metodo que instancia o prefab; o objeto, a posicao, a rotacao padrao do negocio
            Instantiate(canos, source.transform.position, Quaternion.identity);
        }
    }
}
