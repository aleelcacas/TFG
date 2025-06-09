using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuAjustes;
    [SerializeField] private GameObject menuControles;
    [SerializeField] private GameObject pausaMenuPrimero;
    [SerializeField] private GameObject ajustesMenuPrimero;
    [SerializeField] private GameObject controlesMenuPrimero;
    [SerializeField] private PlayerMovement playerMovement;
    private bool pausado;

    void Start()
    {
        pausado = false;
        UnPause();
        menuAjustes.SetActive(false);
        menuPausa.SetActive(false);
        menuControles.SetActive(false);
    }

    void Update()
    {
        if (InputManager.instance.PausaOpenCloseInput)
        {
            if (!pausado)
            {
                Pause();
            }

            else
            {
                UnPause();
            }
        }
    }

    void Pause()
    {
        pausado = true;
        Time.timeScale = 0f;

        playerMovement.enabled = false;

        OpenPauseMenu();
    }

    void UnPause()
    {
        pausado = false;
        Time.timeScale = 1f;

        playerMovement.enabled = true;

        CloseAllMenus();
    }

    void OpenPauseMenu()
    {
        menuPausa.SetActive(true);
        menuAjustes.SetActive(false);
        menuControles.SetActive(false);

        EventSystem.current.SetSelectedGameObject(pausaMenuPrimero);
    }

    void OpenSettingsMenuHandle()
    {
        menuPausa.SetActive(false);
        menuAjustes.SetActive(true);
        menuControles.SetActive(false);

        EventSystem.current.SetSelectedGameObject(ajustesMenuPrimero);
    }

    void OpenControlsMenuHandle()
    {
        menuPausa.SetActive(false);
        menuAjustes.SetActive(false);
        menuControles.SetActive(true);

        EventSystem.current.SetSelectedGameObject(controlesMenuPrimero);
    }

    void CloseAllMenus()
    {
        menuPausa.SetActive(false);
        menuAjustes.SetActive(false);
        menuControles.SetActive(false);
    }

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }

    public void OnControlsPress()
    {
        OpenControlsMenuHandle();
    }

    public void OnResumePress()
    {
        UnPause();
    }

    public void OnSettingsBackPress()
    {
        OpenPauseMenu();
    }

    public void OnControlsBackPress()
    {
        OpenSettingsMenuHandle();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
