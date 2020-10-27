using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Vector2Int onBoardPosition;
    public RectTransform tileRectTransform;
    public BoardGenerator Board;

    public Unit currentUnit = null;

    public Image UnitMoveMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Vector2Int setPosition, BoardGenerator setBoard)
    {
        onBoardPosition = setPosition;
        Board = setBoard;
        tileRectTransform = GetComponent<RectTransform>();
        Debug.Log(onBoardPosition);
    }

    public void KillPiece()
    {
        if (currentUnit != null)
        {
            currentUnit.remove();
        }
    }
}
