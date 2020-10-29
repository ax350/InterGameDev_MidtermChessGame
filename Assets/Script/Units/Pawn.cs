using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SetupUnit(Color TeamColor, faction faction, UnitManager assignedUnitManager)
    {
        base.SetupUnit(TeamColor,faction, assignedUnitManager);
        Debug.Log("1");
        GetComponent<Image>().useSpriteMesh = true;

        //Load Sprite Sheet
        //To further adapt, I can make a public string directing to a specific sprite sheet
        Sprite[] sprites = Resources.LoadAll<Sprite>("ChineseChess");
        Debug.Log(sprites.Length);

        //GetComponent<Image>().sprite = Resources.Load<Sprite>("ChineseChess") as Sprite;
        //GetComponent<Image>().sprite = sprites[10];
        if (unitFaction == faction.black)
        {
            GetComponent<Image>().sprite = sprites[13];
        }
        else
        {
            GetComponent<Image>().sprite = sprites[6];
        }
        
        Debug.Log(GetComponent<Image>().sprite);
        Debug.Log("2");

        if (unitFaction == faction.black)
        {
            //I need to override FindAllMovableTiles() for the black side...
            movableDistance = new Vector3Int(0, -1, -1);
        }
        else
        {
            movableDistance = new Vector3Int(0, 1, 1);
        }
    }

    public override void FindAllMoveableTiles()
    {
        //completly discard the old ones, pawn is way too special
        //base.FindAllMoveableTiles();
        int tile_Xpos = currentTile.onBoardPosition.x;
        int tile_Ypos = currentTile.onBoardPosition.y;

        //Front Corner
        FindMovableTilesForPawn(tile_Xpos - movableDistance.z, tile_Ypos + movableDistance.z, tileStatus.Occupied_by_enemy);
        FindMovableTilesForPawn(tile_Xpos + movableDistance.z, tile_Ypos + movableDistance.z, tileStatus.Occupied_by_enemy);

        //Straight Front
        if (FindMovableTilesForPawn(tile_Xpos, tile_Ypos + movableDistance.y, tileStatus.Empty))
        {
            if (isFirstMove)
            {
                FindMovableTilesForPawn(tile_Xpos, tile_Ypos + movableDistance.y * 2, tileStatus.Empty);
            }
        }
    }

    public Boolean FindMovableTilesForPawn(int targetTile_Xpos, int targetTile_Ypos, tileStatus expectedStatus)
    {
        //base.FindMovableTiles(xDir, yDir, distance);
        //int tile_Xpos = currentTile.onBoardPosition.x;
        //int tile_Ypos = currentTile.onBoardPosition.y;

        tileStatus targetTileStatus = currentTile.Board.CheckAvailability(targetTile_Xpos, targetTile_Ypos, this);

        if (targetTileStatus == expectedStatus)
        {
            movableTiles.Add(currentTile.Board.tileMap[targetTile_Xpos, targetTile_Ypos]);
            return true;
        }
        return false;
    }
}
