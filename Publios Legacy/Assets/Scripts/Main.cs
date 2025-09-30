using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour
{
    public GameObject tilePrefab;       
    public Transform mapParent;         // Tile Container
    public TextMeshProUGUI turnLabel;
    public Button endTurnButton;     

    private int turn = 1;
    private int rows = 5;
    private int cols = 5;
    private float tileSize = 100f;

    void Start()
    {
        UpdateTurnLabel();
        GenerateMap();

        endTurnButton.onClick.AddListener(OnEndTurnPressed);
    }

    void GenerateMap()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                GameObject tileObj = Instantiate(tilePrefab, mapParent);
                RectTransform rt = tileObj.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2(x * tileSize, -y * tileSize);

                // Añadimos botón dinámico a la casilla
                Button b = tileObj.gameObject.AddComponent<Button>();
                Tile tileScript = tileObj.GetComponent<Tile>();
                b.onClick.AddListener(() => tileScript.ToggleSelection());
            }
        }
    }

    void OnEndTurnPressed()
    {
        turn++;
        UpdateTurnLabel();
    }

    void UpdateTurnLabel()
    {
        turnLabel.text = $"Turn: {turn}";
    }
}
