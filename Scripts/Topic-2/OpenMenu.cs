using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code by Andrew Esch

public class OpenMenu : MonoBehaviour
{
    // Prototype Script, non-functioning code
    // Meant to describe how we would open and close a menu using a canvas

    private bool condition = false;

    public GameObject MainMenu;
    Image menuImage;
    RectTransform rectangle;

    void Start()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public Update()
    {
        menuImage = GetComponent<Image>();
        rectangle = menuImage.rectTransform;

        // Load scene for StartMenu on keypress
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("StartMenu");
        }

        // Load MainMenu Canvas if "E" is pressed
        if (Input.GetKey(KeyCode.E))
        {
            MainMenuButton();
        }

        // If button pressed to exit the game
        if (condition)
        {
            ExitGame();
        }
    }

    public void MainMenuButton()
    {
        // Show Main Menu to User
        MainMenu.SetActive(true);
    }


    // Quit Application on condition
    public void ExitGame()
    {
        Application.Quit();
    }

}
