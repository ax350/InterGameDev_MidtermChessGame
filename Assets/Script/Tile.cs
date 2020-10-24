using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2 onBoardPosition;
    public BoardGenerator Board;

    public Unit currentUnit = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Vector2 setPosition, BoardGenerator setBoard)
    {
        onBoardPosition = setPosition;
        Board = setBoard;
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
