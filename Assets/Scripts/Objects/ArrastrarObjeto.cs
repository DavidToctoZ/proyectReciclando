using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrastrarObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;

    private Vector3 initialPos;

    bool bolResetPos= false;
    utils u;
    private void Start()
    {
        initialPos = gameObject.transform.position;
        u = gameObject.AddComponent<utils>();
    }

    void OnMouseDown()
    {
        bolResetPos = false;
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag()
    {

        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
         
    }
    void OnMouseUp()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        bolResetPos = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
          
        if (bolResetPos == true && col.gameObject.tag == "botes") {
            if (col.gameObject.name == gameObject.GetComponent<SetMaterial>().material)
            {
                Destroy(gameObject);
                GameManagerClasificacion.puntaje = u.addPoints(GameManagerClasificacion.puntaje);
            }
            else
            {
                GameManagerClasificacion.puntaje = u.minusPoint(GameManagerClasificacion.puntaje);
                resetPosition();
            }
            bolResetPos = false;
        }
    }

    void resetPosition()
    {

        
        transform.position = initialPos;
    }
}
