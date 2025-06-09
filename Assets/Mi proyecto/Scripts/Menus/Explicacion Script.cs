using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplicacionScript : MonoBehaviour
{
    public GameObject texto1, texto2;

    void Start()
    {
        texto1.SetActive(true);
        texto2.SetActive(false);
    }

    public void boton()
    {
        texto2.SetActive(true);
        texto1.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
