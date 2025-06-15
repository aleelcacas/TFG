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
    private PlayerMovement playerMovement;
    public GameObject dataManager;
    private MenuManager menuManager;
    public GameObject seleccion;
    public GameObject blackImage;
    public GameObject[] todos;
    private MovementBetweenRooms mv;
    public Vector3 posicionActualGrid, posicionBuscada;
    public bool mapaAbierto, salasEncontradas, pausaAbierta;
    private bool canOpenTp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuManager = dataManager.GetComponent<MenuManager>();
        Time.timeScale = 1;
        posicionActualGrid = Vector3.zero;
        mv = GetComponent<MovementBetweenRooms>();
        playerMovement = GetComponent<PlayerMovement>();
        StartCoroutine(Iniciar());
    }

    // Update is called once per frame
    void Update()
    {
        if (!salasEncontradas)
            return;

        SelectedOne();
        posicionBuscada = new Vector3(540, 0, 0);
        posicionBuscada += new Vector3(220 * posicionActualGrid.x, 110 * posicionActualGrid.y, 0);
        mv.gridPos = posicionActualGrid;


        if (InputManager.instance.InteractPressed && canOpenTp && !pausaAbierta)
        {
            if (mapaAbierto)
            {
                menuManager.tpAbierto = false;
                playerMovement.enabled = true;
                Time.timeScale = 1;
                mapaInterfaz.SetActive(false);
                mapaAbierto = false;
            }
            else
            {
                menuManager.tpAbierto = true;
                playerMovement.enabled = false;
                Time.timeScale = 0;
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
        blackImage.SetActive(false);
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
            if (obj.name.StartsWith("Button") && Vector3.Distance(obj.transform.localPosition, posicionBuscada) < 0.1f)
            {
                seleccion = obj;
            }
        }

        if (seleccion == null)
            Debug.LogWarning("No encuentro na en: " + posicionBuscada);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjetoTp"))
        {
            canOpenTp = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjetoTp"))
        {
            canOpenTp = false;
        }
    }

    public void CambiarPosicionEnGrid(Vector3 offset)
    {
        posicionActualGrid += offset;
    }

    public void CloseTeleporUI()
    {
        playerMovement.enabled = true;
        Time.timeScale = 1;
        mapaInterfaz.SetActive(false);
        mapaAbierto = false;
    }

    public void ActivarTp()
    {
        Button buton = seleccion.GetComponent<Button>();
        buton.interactable = true;
        ColorBlock cb = buton.colors;
        cb.normalColor = Color.green;
        buton.colors = cb;
    }
}
