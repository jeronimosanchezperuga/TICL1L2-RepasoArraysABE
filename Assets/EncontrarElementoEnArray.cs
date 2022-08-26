using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarElementoEnArray : MonoBehaviour
{
    //1. Crear un array public de gameobjects
    public GameObject[] arrayDeMesas;

    // Start is called before the first frame update
    void Start()
    {
        //2. asignar todos los objetos tageados como "Mesa" al array
        arrayDeMesas = GameObject.FindGameObjectsWithTag("Mesa");
        AddMesaScriptAndSetDestructible();
    }

    // Update is called once per frame
    void Update()
    {
        //4. Invocar la función al presionar el cero alfanumérico
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //DeactivateObjectsInArray();
            DestroyDestructible();

        }
    }
    // 3. Crear una función que desactive todos los elementos del array
    void DeactivateObjectsInArray()
    {
        for (int i = 0; i<arrayDeMesas.Length;i++)
        {
            arrayDeMesas[i].SetActive(false);
        }
    }

    //5. Crear una función que asigne a todos los elementos del array
    // el script mesa. Establecer el valor de la variable 
    // "destructible" aleatoriamente.

    void AddMesaScriptAndSetDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            go.AddComponent<Mesa>();       
            go.GetComponent<Mesa>().destructible = Random.Range(0, 2) == 0;          
        }
    }

    //6. Crear una función que destruya el elemento del array 
    //que contenga un script "Mesa" cuya variable 
    //booleana "destructible" sea true (crear el script "Mesa").

    void DestroyDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            if (go.GetComponent<Mesa>().destructible)
            {
                Destroy(go);
            }
        }
    }



}
