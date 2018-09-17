using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    [SerializeField] GameObject menu;
    public static bool menuIsClosed = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuIsClosed)
        {
            menu.SetActive(true);
            menuIsClosed = false; 
        }
    }
}
