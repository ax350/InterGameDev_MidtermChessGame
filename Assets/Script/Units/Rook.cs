using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rook : Unit
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
            GetComponent<Image>().sprite = sprites[10];
        }
        else
        {
            GetComponent<Image>().sprite = sprites[3];
        }

        Debug.Log(GetComponent<Image>().sprite);

        movableDistance = new Vector3Int(7, 7, 0);
    }
}
