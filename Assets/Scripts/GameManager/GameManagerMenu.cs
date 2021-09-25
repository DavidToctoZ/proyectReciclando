using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    utils u;
    public Button yourButton;
    void Start()
    {
        u = gameObject.AddComponent<utils>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(passScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void passScene()
    {
        u.loadscene("Recoleccion");
    }
}
