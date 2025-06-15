using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private GameObject menuControles;
    [SerializeField] private GameObject mainMenuPrimero;
    [SerializeField] private GameObject ajustesMenuPrimero;
    [SerializeField] private GameObject controlesMenuPrimero;
    [SerializeField] private GameObject menuMejoras;
    [SerializeField] private GameObject mejorasMenuPrimero;


    void Start()
    {
        mainMenu.SetActive(true);
        menuAjustes.SetActive(false);
        menuControles.SetActive(false);
        menuMejoras.SetActive(false);

        EventSystem.current.SetSelectedGameObject(mainMenuPrimero);
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        menuAjustes.SetActive(false);
        menuControles.SetActive(false);
        menuMejoras.SetActive(false);

        EventSystem.current.SetSelectedGameObject(mainMenuPrimero);
    }

    public void OpenMenuAjustes()
    {
        mainMenu.SetActive(false);
        menuAjustes.SetActive(true);
        menuControles.SetActive(false);
        menuMejoras.SetActive(false);

        EventSystem.current.SetSelectedGameObject(ajustesMenuPrimero);
    }

    public void OpenMenuControles()
    {
        mainMenu.SetActive(false);
        menuAjustes.SetActive(false);
        menuControles.SetActive(true);
        menuMejoras.SetActive(false);

        EventSystem.current.SetSelectedGameObject(controlesMenuPrimero);
    }

    public void OpenMenuMejoras()
    {
        mainMenu.SetActive(false);
        menuAjustes.SetActive(false);
        menuControles.SetActive(false);
        menuMejoras.SetActive(true);

        EventSystem.current.SetSelectedGameObject(mejorasMenuPrimero);
    }

    public void HacerSonido()
    {

    }
}
