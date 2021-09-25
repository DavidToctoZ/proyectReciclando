using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class utils : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadscene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public int addPoints(int t)
    {
        t = t + 1;
        return t;
    }

    public int minusPoint(int t)
    {
        t = t - 1;
        return t;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
