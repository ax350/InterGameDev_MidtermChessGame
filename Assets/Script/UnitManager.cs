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
    int tmpUnitnumbers = 16;
    public Unit[] availableUnits = new Unit[16];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupPieces(BoardGenerator Board)
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
            //For now it will all be basic chess piece

            GameObject newUnit = Instantiate(UnitPrefab,transform);

            Unit newU = (Unit)newUnit.AddComponent(typeof(Pawn));
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

    public void SwitchTurn(faction unitFaction)
    {
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
