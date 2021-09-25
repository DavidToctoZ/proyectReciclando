using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerClasificacion : MonoBehaviour
{
    // Start is called before the first frame update

    public Text textTiempo;
    public Text textPuntaje;

    public static float tiempo = 60;
    public static int puntaje = 0;
    public GameObject padreObjetos;
    public List<GameObject> listaObjetosSet;

    utils u;
    int total;
    void Start()
    {
        u = gameObject.AddComponent<utils>();
        generacionObjetosMapa();

    }


    // Update is called once per frame
    void Update()
    {
        print(puntaje);
        if (puntaje <= 0)
        {
            puntaje = 0;

        }
        tiempo -= Time.deltaTime;

        textTiempo.text = ((int)tiempo).ToString();
        textPuntaje.text = puntaje.ToString();


        total = GameObject.Find("generateObjects").transform.childCount;
        if (total <= 0 || tiempo <= 0)
        {
            u.loadscene("Usos");
        }
    }

    public void generacionObjetosMapa()
    {
        foreach (Dictionary<string, string> i in GameManagerRecoleccion.listObjetosRecolectados)
        {
            generarObjeto(i["material"], i["tipo"]);
        }
    }

    public void generarObjeto(string material, string tipo)
    {
        foreach (GameObject t in listaObjetosSet)
        {
            if( material == t.GetComponent<SetMaterial>().material && tipo == t.GetComponent<SetMaterial>().tipo)
            {
                Vector3 tmpPos;
                tmpPos.x = Random.Range(-8.0f, 8.0f);
                tmpPos.y = Random.Range(0.0f, -3.0f);
                tmpPos.z = 0;
                GameObject newGameObject = Instantiate(t, tmpPos, Quaternion.identity);
                newGameObject.transform.parent = padreObjetos.transform;
                newGameObject.AddComponent<ArrastrarObjeto>();
                newGameObject.AddComponent<Rigidbody2D>();
                newGameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
                  
        }

    }

}
