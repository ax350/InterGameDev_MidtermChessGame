using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//add enum to this later, there will be different factions
//you know what fuck this, I'm adding this now
public enum faction
{ 
    white,
    black,
    thrid_party
}

public abstract class Unit : EventTrigger
{
    //UnitManager here
    UnitManager unitManager;

    private Tile originalTile = null;
    private Tile currentTile = null;
    private Tile targetTile = null;

    public Color pColor = Color.blue;
    public faction unitFaction;

    //Go-to-able tiles
    //This is for the distance of movement
    private Vector3Int movableDistance = Vector3Int.one;
    //This is the list of all the tiles that this unit can go to
    private List<Tile> movableTiles = new List<Tile>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetupUnit(Color TeamColor, faction faction, UnitManager assignedUnitManager)
    {
        //UnitManager here
        unitManager = assignedUnitManager;

        pColor = TeamColor;
        GetComponent<Image>().color = pColor;
        unitFaction = faction;
    }

    public void placeSelf(Tile initialTile)
    {
        currentTile = initialTile;
        originalTile = initialTile;
        currentTile.currentUnit = this;

        transform.position = currentTile.transform.position;
        Debug.Log(transform.position);
    }

    public virtual void remove()
    {
        currentTile.currentUnit = null;
        
        //Add: Play animation
        
        gameObject.SetActive(false);
    }

    public void resetSelf()
    {
        remove();
        placeSelf(originalTile);
    }

    public void FindMovableTiles(int xDir, int yDir, int distance)
    {
        //this first gets the current xy pos of the tile this unit is on
        //then it will be used to check all the tile this unit can move to
        int tile_Xpos = currentTile.onBoardPosition.x;
        int tile_Ypos = currentTile.onBoardPosition.y;

        //this loop will go through all the tiles this unit can move to, therefore int i will start with a minimal 1
        //but maybe I'll add some sort of "unable to move" state for later development?
        for (int i = 1; i <= distance; i++)
        {
            tile_Xpos += xDir;
            tile_Ypos += yDir;

            //TODO: Check if the cell is occupied
            //Working on it
            tileStatus tileStatus = tileStatus.Idle;
            tileStatus = currentTile.Board.CheckAvailability(tile_Xpos, tile_Ypos, this);

            if (tileStatus == tileStatus.Occupied_by_enemy)
            {
                movableTiles.Add(currentTile.Board.tileMap[tile_Xpos, tile_Ypos]);
                break;
            }

            if (tileStatus != tileStatus.Empty)
            {
                break;
            }

            movableTiles.Add(currentTile.Board.tileMap[tile_Xpos,tile_Ypos]);
        }
    }

    void FindAllMoveableTiles()
    {
        FindMovableTiles(1, 0, movableDistance.x);
        FindMovableTiles(-1, 0, movableDistance.x);
        FindMovableTiles(0, 1, movableDistance.y);
        FindMovableTiles(0, -1, movableDistance.y);
    }

    void MaskMovableTiles()
    {
        foreach (Tile tmptile in movableTiles)
        {
            tmptile.UnitMoveMask.enabled = true;
        }
    }

    void ClearAllMovableTiles()
    {
        foreach (Tile tmptile in movableTiles)
        {
            tmptile.UnitMoveMask.enabled = false;
        }
        movableTiles.Clear();
    }

    protected virtual void moveUnit()
    {
        Debug.Log("Is moving Unit!");
        //Swap the target tile to the current tile
        targetTile.KillPiece();
        currentTile.currentUnit = null;
        currentTile = targetTile;
        currentTile.currentUnit = this;
        transform.position = currentTile.transform.position;
        targetTile = null;
    }

    #region DragEvent
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        FindAllMoveableTiles();
        MaskMovableTiles();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        //Debug.Log(transform.position);
        transform.position += (Vector3)eventData.delta;

        foreach (Tile tmptile in movableTiles)
        {
            Debug.Log(tmptile.tileRectTransform);
            Debug.Log(Input.mousePosition);
            if (RectTransformUtility.RectangleContainsScreenPoint(tmptile.tileRectTransform, Input.mousePosition))
            {
                targetTile = tmptile;
                break;
            }
            targetTile = null;
        }

        //Debug.Log(transform.position);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ClearAllMovableTiles();

        if (targetTile == null)
        {
            transform.position = currentTile.transform.position;
            return;
        }

        moveUnit();

        unitManager.SwitchTurn(unitFaction);
    }
    #endregion
}
