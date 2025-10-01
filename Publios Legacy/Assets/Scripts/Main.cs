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
    private const float TILE_SIZE = 50f;

    void Start()
    {
        UpdateTurnLabel();
        GenerateMap();

        endTurnButton.onClick.AddListener(OnEndTurnPressed);
    }

    void GenerateMap()
    {
        float mapWidth = cols * TILE_SIZE;
        float mapHeight = rows * TILE_SIZE;

        float startX = -mapWidth / 2 + TILE_SIZE / 2;
        float startY = mapHeight / 2 - TILE_SIZE / 2;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                GameObject tileObj = Instantiate(tilePrefab, mapParent);
                RectTransform rt = tileObj.GetComponent<RectTransform>();

                // Ajustar tamaño del tile al tileSize
                rt.sizeDelta = new Vector2(TILE_SIZE, TILE_SIZE);

                // Posición centrada
                rt.anchoredPosition = new Vector2(startX + x * TILE_SIZE, startY - y * TILE_SIZE);

                // Añadir botón para que responda al click
                Button b = tileObj.AddComponent<Button>();
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
