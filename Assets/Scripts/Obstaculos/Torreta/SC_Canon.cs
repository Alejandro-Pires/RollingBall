using System.Collections.Generic;
using UnityEngine;

namespace Obstaculos.Torreta
{
    public class SC_Canon : MonoBehaviour
    {
        [Header("Configuración del Cañón")]
        [SerializeField] private GameObject prefabProyectil;
        [SerializeField] private Transform puntoDisparo;
        [SerializeField] private float cadencia = 4f;
        [SerializeField] private int tamanoPool = 5;

        //Se crea una "Cola" (Queue) para el Pool "FIFO" (first in firs out).
        private Queue<GameObject> poolProyectiles = new Queue<GameObject>();
        private float timer;

        private void Start()
        {
            for (int i = 0; i < tamanoPool; i++)
            {
                GameObject obj = Instantiate(prefabProyectil, transform.position, Quaternion.identity);
                obj.SetActive(false);
                poolProyectiles.Enqueue(obj);
            }
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= cadencia)
            {
                Disparar();
                timer = 0;
            }
        }

        private void Disparar()
        {
            // Se saca la bala más antigua / se enciende / se pone al final de la Queue
            if (poolProyectiles.Count <= 0) return;
            GameObject proyectil = poolProyectiles.Dequeue();
        
            proyectil.transform.position = puntoDisparo.position;
            proyectil.transform.rotation = puntoDisparo.rotation;
            proyectil.SetActive(true);

            poolProyectiles.Enqueue(proyectil);
        }
    }
}