using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void remove()
    {
        base.remove();

        unitManager.winState = true;
    }

    public override void SetupUnit(Color TeamColor, faction faction, UnitManager assignedUnitManager)
    {
        base.SetupUnit(TeamColor, faction, assignedUnitManager);
        GetComponent<Image>().useSpriteMesh = true;

        Sprite[] sprites = Resources.LoadAll<Sprite>("ChineseChess");
        Debug.Log(sprites.Length);

        if (unitFaction == faction.black)
        {
            GetComponent<Image>().sprite = sprites[7];
        }
        else
        {
            GetComponent<Image>().sprite = sprites[0];
        }

        Debug.Log(GetComponent<Image>().sprite);

        movableDistance = new Vector3Int(1, 1, 1);
    }
}
