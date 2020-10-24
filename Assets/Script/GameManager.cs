using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public BoardGenerator gameBoard;
    public UnitManager gameUnitManager;
    // Start is called before the first frame update
    void Start()
    {
        /*
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DontDestroyOnLoad(singleton);
        }
        */

        gameBoard.MakeBoard();
        gameUnitManager.SetupPieces(gameBoard);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
