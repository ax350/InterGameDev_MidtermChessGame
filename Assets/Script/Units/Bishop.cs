using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bishop : Unit
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
        //Sprite Stuff
        base.SetupUnit(TeamColor, faction, assignedUnitManager);
        GetComponent<Image>().useSpriteMesh = true;

        Sprite[] sprites = Resources.LoadAll<Sprite>("ChineseChess");
        Debug.Log(sprites.Length);

        if (unitFaction == faction.black)
        {
            GetComponent<Image>().sprite = sprites[12];
        }
        else
        {
            GetComponent<Image>().sprite = sprites[5];
        }

        Debug.Log(GetComponent<Image>().sprite);

        //Movement-Hard wired, since I don't intend to further touch upon chess
        movableDistance = new Vector3Int(0, 0, 7);
    }
}
