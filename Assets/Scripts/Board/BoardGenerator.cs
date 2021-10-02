using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    private static BoardGenerator _instance;
    public static BoardGenerator Main
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<BoardGenerator>();

                if(_instance == null)
                {
                    _instance = new GameObject("Board").AddComponent<BoardGenerator>();
                }
            }

            return _instance;
        }
    }


    [SerializeField] private Vector2 boardSize;
    [SerializeField] private Color[] cellColors;
    [SerializeField] private Sprite cellBG;

    private List<BoardCell> cells = new List<BoardCell>();



    [ContextMenu("GenerateBoard")]
    private void GenerateBoard()
    {
        for (int i = 0; i < boardSize.x; i++)
        {
            for (int j = 0; j < boardSize.y; j++)
            {
                GameObject container = new GameObject("Cell");
                container.transform.SetParent(this.transform);
                BoardCell cellComponent = container.AddComponent<BoardCell>();

                cellComponent.SetCellPosition(new Vector2(i, j), boardSize / 2, cellColors, cellBG);

                cells.Add(cellComponent);
            }
        }
    }


    [ContextMenu("Destroy")]
    private void DestroyBoard()
    {
        foreach(BoardCell cell in GetComponentsInChildren<BoardCell>())
        {
            DestroyImmediate(cell.gameObject);
        }
    }
}
