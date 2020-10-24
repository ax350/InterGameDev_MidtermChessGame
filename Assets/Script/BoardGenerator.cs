using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Tile[,] tileMap;


    // Start is called before the first frame update
    void Start()
    {
        tileMap = new Tile[Board_Size_x, Board_Size_y];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBoard()
    {
        for (int y = 0; y < Board_Size_y; y++)
        {
            //Create Offset for 8*8 board specifically
            ColorSwitchFlag = !ColorSwitchFlag;
            for (int x = 0; x < Board_Size_x; x++)
            {
                //Generate the tile
                GameObject newTile = Instantiate(TilePrefab,transform);
                Debug.Log(newTile);

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
}
