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
    public GameObject seleccion;
    public GameObject[] todos;
    public Vector3 posicionActualGrid, posicionBuscada;
    public bool mapaAbierto, salasEncontradas;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionActualGrid = Vector3.zero;
        StartCoroutine(Iniciar());
    }

    // Update is called once per frame
    void Update()
    {
        if (!salasEncontradas)
            return;
        posicionBuscada = new Vector3(540, 0 ,0);
        posicionBuscada += new Vector3(220 * posicionActualGrid.x, 110 * posicionActualGrid.y, 0);

        
        if (InputManager.instance.InteractPressed)
        {
            if (mapaAbierto)
            {
                mapaInterfaz.SetActive(false);
                mapaAbierto = false;
            }
            else
            {
                SelectedOne();
                mapaInterfaz.SetActive(true);
                mapaAbierto = true;
                EventSystem.current.SetSelectedGameObject(seleccion);
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
            Debug.Log("Soy: " + obj.name + " estoy en " + obj.transform.localPosition);
            if (obj.name.StartsWith("Button") && Vector3.Distance(obj.transform.localPosition, posicionBuscada) < 0.1f)
            {
                seleccion = obj;
            }
        }
        
        if (seleccion == null)
        Debug.LogWarning("No encuentro na en: " + posicionBuscada);
    }

    public void CambiarPosicionEnGrid(Vector3 offset)
    {
        posicionActualGrid += offset;
    }
}
