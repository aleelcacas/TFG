using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerEscenas : MonoBehaviour
{
    public void EscenaPruebas()
    {
        SceneManager.LoadScene("pruebas");
    }
    public void EscenaSample()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void EscenaExplicacion()
    {
        SceneManager.LoadScene("Explicacion");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
