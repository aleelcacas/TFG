using System.Collections;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractuarTp : MonoBehaviour
{
    [SerializeField] private GameObject mapaInterfaz;
    [SerializeField] private GameObject MapRoot;
    public GameObject poepo;
    public GameObject[] todos;
    private string nombreBotones;
    public Vector3 posicionActualGrid, posicionBuscada;
    public bool mapaAbierto, salasEncontradas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nombreBotones = "Button(Clone)";
        posicionActualGrid = Vector3.zero;
        StartCoroutine(Iniciar());
    }

    // Update is called once per frame
    void Update()
    {
        if (!salasEncontradas)
            return;
        posicionBuscada = posicionActualGrid * 16;

        SelectedOne();

        if (InputManager.instance.InteractPressed)
        {
            if (mapaAbierto)
            {
                mapaInterfaz.SetActive(false);
                mapaAbierto = false;
            }
            else
            {
                mapaInterfaz.SetActive(true);
                mapaAbierto = true;
                EventSystem.current.SetSelectedGameObject(poepo);
            }
        }
    }

    IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(0.1f);
        BuscarSalas();
        salasEncontradas = true;
        mapaInterfaz.SetActive(false);
    }
    void BuscarSalas()
    {
        todos = GameObject.FindGameObjectsWithTag("Mapa");
    }
    void SelectedOne()
    {
        foreach (GameObject obj in todos)
        {
            if (obj.name == nombreBotones && obj.transform.position == posicionBuscada)
            {
                poepo = obj; 
                Debug.Log("Hola");
            }
        }
    }

    public void CambiarPosicionEnGrid(Vector3 offset)
    {
        posicionActualGrid += offset;
    }
}
