using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum tileStatus
{
    Idle,
    Empty,
    Occupied_by_friendly,
    Occupied_by_enemy,
    OutOfBounds
}

public class BoardGenerator : MonoBehaviour
{
    #region Create Board
    public int Board_Size_x;
    public int Board_Size_y;
    public GameObject TilePrefab;
    public Color Tile_color1;
    public Color Tile_color2;
    Boolean ColorSwitchFlag = false;
    //public GameObject TilePrefab;
    #endregion

    //[HideInInspector]
    public Tile[,] tileMap;


    // Start is called before the first frame update
    void Start()
    {
        //MakeBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBoard()
    {
        tileMap = new Tile[Board_Size_x, Board_Size_y];
        for (int y = 0; y < Board_Size_y; y++)
        {
            //Create Offset for 8*8 board specifically
            ColorSwitchFlag = !ColorSwitchFlag;
            for (int x = 0; x < Board_Size_x; x++)
            {
                //Generate the tile
                GameObject newTile = Instantiate(TilePrefab,transform);
                //Debug.Log(newTile);

                //Position
                newTile.GetComponent<RectTransform>().anchoredPosition = new Vector2( x * 100 + 50 - Board_Size_x / 2 * 100, y * 100 + 50 - Board_Size_y / 2 * 100);

                //Color
                
                if (ColorSwitchFlag)
                {
                    newTile.GetComponent<Image>().color = Tile_color1;
                    ColorSwitchFlag = false;
                }
                else
                {
                    newTile.GetComponent<Image>().color = Tile_color2;
                    ColorSwitchFlag = true;
                }

                //Tile Property Setup
                tileMap[x, y] = newTile.GetComponent<Tile>();
                tileMap[x, y].Setup(new Vector2Int(x, y), this);
            }
        }
    }

    public tileStatus CheckAvailability(int xPos, int yPos, Unit callingUnit)
    {
        if (xPos < 0 || xPos >= Board_Size_x)
        {
            return tileStatus.OutOfBounds;
        }

        if (yPos < 0 || yPos >= Board_Size_y)
        {
            return tileStatus.OutOfBounds;
        }

        Tile targetTile = tileMap[xPos, yPos];

        if (targetTile.currentUnit != null)
        {
            if (targetTile.currentUnit.unitFaction == callingUnit.unitFaction)
            {
                return tileStatus.Occupied_by_friendly;
            }
            if (targetTile.currentUnit.unitFaction != callingUnit.unitFaction)
            {
                return tileStatus.Occupied_by_enemy;
            }
        }

        return tileStatus.Empty;
    }

}
