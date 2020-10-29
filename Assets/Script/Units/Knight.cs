using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : Unit
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
        base.SetupUnit(TeamColor, faction, assignedUnitManager);
        GetComponent<Image>().useSpriteMesh = true;

        Sprite[] sprites = Resources.LoadAll<Sprite>("ChineseChess");
        Debug.Log(sprites.Length);

        if (unitFaction == faction.black)
        {
            GetComponent<Image>().sprite = sprites[9];
        }
        else
        {
            GetComponent<Image>().sprite = sprites[2];
        }

        Debug.Log(GetComponent<Image>().sprite);
    }

    public override void FindAllMoveableTiles()
    {
        //base.FindAllMoveableTiles();
        int tile_Xpos = currentTile.onBoardPosition.x;
        int tile_Ypos = currentTile.onBoardPosition.y;

        FindMovableTilesForKnight(tile_Xpos - 2, tile_Ypos - 1);
        FindMovableTilesForKnight(tile_Xpos + 2, tile_Ypos - 1);
        FindMovableTilesForKnight(tile_Xpos - 2, tile_Ypos + 1);
        FindMovableTilesForKnight(tile_Xpos + 2, tile_Ypos + 1);
        FindMovableTilesForKnight(tile_Xpos - 1, tile_Ypos - 2);
        FindMovableTilesForKnight(tile_Xpos + 1, tile_Ypos - 2);
        FindMovableTilesForKnight(tile_Xpos - 1, tile_Ypos + 2);
        FindMovableTilesForKnight(tile_Xpos + 1, tile_Ypos + 2);
    }

    private void FindMovableTilesForKnight(int targetTile_Xpos, int targetTile_Ypos)
    {
        tileStatus targetTileStatus = currentTile.Board.CheckAvailability(targetTile_Xpos, targetTile_Ypos, this);

        if (targetTileStatus != tileStatus.Occupied_by_friendly && targetTileStatus != tileStatus.OutOfBounds)
        {
            movableTiles.Add(currentTile.Board.tileMap[targetTile_Xpos, targetTile_Ypos]);
        }
    }
}
