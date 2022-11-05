using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameNavigation : MonoBehaviour
{
    public GameObject player, pointer;
    public Button returnButton, lobbyButton, quitButton;
    private bool activated;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        pointer.SetActive(false);
        activated = false;
        returnButton.onClick.AddListener(TaskOnClick_Return);
        lobbyButton.onClick.AddListener(TaskOnClick_SpaceStation);
        quitButton.onClick.AddListener(TaskOnClick_Quit);
    }


    void TaskOnClick_Return()
    {
        // Exit the game
        player.SetActive(true);
        pointer.SetActive(false);
        activated = false;
    }

    void TaskOnClick_SpaceStation()
    {
        // Go to space station scene (using loading screen)
        SceneManager.LoadScene("SpaceHallwayLoadingScreen");
    }

    void TaskOnClick_Quit()
    {
        // Exit the game
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start, OVRInput.Controller.LTouch) && activated == false)
        {
            player.SetActive(false);
            pointer.SetActive(true);
            activated = true;
        }
        else if (Input.GetKey("s") && activated == false)
        {
            player.SetActive(false);
            pointer.SetActive(true);
            activated = true;
        }
    }

    IEnumerator sleep(int n)
    {
        yield return new WaitForSeconds(n);
    }
}
