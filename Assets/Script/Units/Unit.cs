using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Unit : EventTrigger
{
    //PieceManager

    private Tile originalTile = null;
    private Tile currentTile = null;

    public Color pColor = Color.blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetupUnit(Color TeamColor)
    {
        //PieceManager

        pColor = TeamColor;
    }

    public void PlaceSelf(Tile initialTile)
    {
        currentTile = initialTile;
        originalTile = initialTile;
        currentTile.currentUnit = this;

        transform.position = currentTile.transform.position;
    }

    public virtual void remove()
    {
        currentTile.currentUnit = null;
        
        //Add: Play animation
        
        gameObject.SetActive(false);
    }
}
