using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerUsos : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textTiempo;
    public Text textPuntaje;

    public static float tiempo = 60;
    public static int puntaje = 0;
    utils u;
    int total;
    void Start()
    {
        u = gameObject.AddComponent<utils>();
// total = GameObject.Find("objetos").transform.childCount;
        total = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (puntaje <= 0)
        {
            puntaje = 0;

        }
        tiempo -= Time.deltaTime;

        textTiempo.text = ((int)tiempo).ToString();
        textPuntaje.text = puntaje.ToString();
        if (total == puntaje || tiempo <= 0)
        {
            u.loadscene("Menu");
        }
    }

}
