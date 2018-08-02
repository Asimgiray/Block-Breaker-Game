using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    // Use this for initialization
    public void StartGame()
    {
        Application.LoadLevel(1);
    }
    public void returnGame()
    {
        Application.LoadLevel(0);
    }
    public void Quit()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
