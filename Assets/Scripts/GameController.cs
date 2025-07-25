using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject menu, passaro, canos, source;
    [SerializeField] private float intervaloCano;
    private bool starting;

    // Start is called before the first frame update
    void Start()
    {
        starting = true;
        InvokeRepeating("SpawnCanos", 0f, intervaloCano);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && starting)
        {
            Destroy(menu);
            passaro.SetActive(true);
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
}
