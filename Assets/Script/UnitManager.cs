using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject UnitPrefab;

    private List<Unit> whiteUnits = null;
    private List<Unit> blackUnits = null;

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
        whiteUnits = CreateUnits(Color.white);
        blackUnits = CreateUnits(Color.black);

        PlaceUnits(1, 0, whiteUnits, Board);
        PlaceUnits(6, 7, blackUnits, Board);

    }

    private List<Unit> CreateUnits(Color teamColor)
    {
        List<Unit> newUnits = new List<Unit>();

        for (int i = 0; i < tmpUnitnumbers; i++)
        {
            //Get the type of Unit here
            //For now it will all be basic chess piece

            GameObject newUnit = Instantiate(UnitPrefab,transform);

            Unit newU = (Unit)newUnit.AddComponent(typeof(Pawn));
            newU.SetupUnit(teamColor);
            
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
                Units[i].PlaceSelf(Board.tileMap[i, StartRow]);
            }
            else
            {
                Units[i].PlaceSelf(Board.tileMap[i - 8, EndRow]);
            }
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
