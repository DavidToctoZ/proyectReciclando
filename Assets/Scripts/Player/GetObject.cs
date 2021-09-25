using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    // Start is called before the first frame update
    //Transformar a static
    int contObjetos;
    
    utils u;
    void Start()
    {
        u = gameObject.AddComponent<utils>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
    
        if(col.gameObject.tag == "objetos"){
            Destroy(col.gameObject);
            contObjetos++;
            Dictionary<string, string> objetoRecolectado = new Dictionary<string, string>();
            objetoRecolectado.Add("nombre",col.gameObject.name);
            objetoRecolectado.Add("material", col.gameObject.GetComponent<SetMaterial>().material);
            objetoRecolectado.Add("tipo", col.gameObject.GetComponent<SetMaterial>().tipo);
            GameManagerRecoleccion.listObjetosRecolectados.Add(objetoRecolectado);
          
            GameManagerRecoleccion.puntaje = u.addPoints(GameManagerRecoleccion.puntaje);
            

        }
        
    }
}
