using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject UnitPrefab;

    private List<Unit> whiteUnits = null;
    private List<Unit> blackUnits = null;

    public Boolean winState = false;
    public Boolean bonusState = false;

    //There will be a unit selection later, current 16 is the chess numbers
    public static int tmpUnitnumbers = 16;
    /*
    public Unit[] availableUnits = new Unit[16];
    {
        new Pawn pawn,new Pawn pawn,new Pawn,Pawn,Pawn,Pawn,Pawn,Pawn,
        Rook, Knight, Bishop, Queen, King, Bishop, Knight, Rook
    };
    */
    //List length would change based on levels
    private string[] unitNameList = new string[16]
    {
        "P","P","P","P","P","P","P","P",
        "R","K","B","Q","KG","B","K","R"
    };

    //remind myself that there might be a way to edit dic dynamically
    public Dictionary<string, Type> unitTypeList = new Dictionary<string, Type>()
    {
        {"P", typeof(Pawn)},
        {"R", typeof(Rook)},
        {"K", typeof(Knight)},
        {"B", typeof(Bishop)},
        {"Q", typeof(Queen)},
        {"KG", typeof(King)},
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupUnits(BoardGenerator Board)
    {
        whiteUnits = CreateUnits(Color.white, faction.white);
        blackUnits = CreateUnits(Color.black, faction.black);

        PlaceUnits(1, 0, whiteUnits, Board);
        PlaceUnits(6, 7, blackUnits, Board);

        //Replace with enum later
        ChangeInteractivity(blackUnits, false);
    }

    private List<Unit> CreateUnits(Color teamColor, faction unitFaction)
    {
        List<Unit> newUnits = new List<Unit>();

        for (int i = 0; i < tmpUnitnumbers; i++)
        {
            //Get the type of Unit here
            Type unitType = unitTypeList[unitNameList[i]];
            //For now it will all be basic chess piece

            GameObject newUnit = Instantiate(UnitPrefab,transform);

            Unit newU = (Unit)newUnit.AddComponent(unitType);
            newU.SetupUnit(teamColor, unitFaction, this);
            
            newUnits.Add(newU);

        }
        return newUnits;
    }

    private void PlaceUnits(int StartRow, int EndRow, List<Unit> Units, BoardGenerator Board) //Map levelMap
    {
        //There will be other maps, depend on the map there will be specific places
        for (int i = 0; i < tmpUnitnumbers; i++)
        {
            if (i < 8)
            {
                Debug.Log(i+" "+ Units[i].GetType());
                Units[i].placeSelf(Board.tileMap[i, StartRow]);
            }
            else
            {
                Units[i].placeSelf(Board.tileMap[i - 8, EndRow]);
            }
        }
    }

    public void ResetUnits()
    {
        foreach (Unit unit in whiteUnits)
        {
            unit.resetSelf();
        }
        foreach (Unit unit in blackUnits)
        {
            unit.resetSelf();
        }
    }

    public void SwitchTurn(faction unitFaction)
    {
        //Specific for chess
        if (winState)
        {
            ResetUnits();
            winState = false;
            unitFaction = faction.black;
        }


        //There will be battle among three or more factions, prepare an enum list for this later
        bool blackTurn;
        //bool whiteTurn;
        if (unitFaction == faction.white)
        {
            blackTurn = true;
        }
        else
        {
            blackTurn = false;
        }

        ChangeInteractivity(whiteUnits, !blackTurn);
        ChangeInteractivity(blackUnits, blackTurn);
    }
    private void ChangeInteractivity(List<Unit> allFactionUnit, bool boolean)
    {
        foreach (Unit unit in allFactionUnit)
        {
            unit.enabled = boolean;
        }
    }

    /*
    private Unit CreateUnit()
    {
        GameObject newUnit = Instantiate(UnitPrefab, new Vector3(), Quaternion.identity);
        newUnit.transform.localScale = new Vector3(1, 1, 1);

        Unit tmpUnit = (Unit)newUnit;
    }
    */
}
