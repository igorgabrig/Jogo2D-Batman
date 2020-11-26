using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataformaSobeDesce : MonoBehaviour
{
    private float count = 0;
    public float velocidade = 0.5f;
    private Vector2 posInicial;
    public float altura = 5;

    public float largura = 0;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        count += velocidade * Time.deltaTime;

        float posX = Mathf.Cos(count) * largura;
        float posY = Mathf.Sin(count) * altura;

        Vector2 posAtual = new Vector2(posX, posY);

        transform.position = posInicial + posAtual;

        if(count >=2 * Mathf.PI){
            count = 2 * Mathf.PI - count;
        }

    }
}
