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

    public override void SetupUnit(Color TeamColor)
    {
        base.SetupUnit(TeamColor);
        Debug.Log("111");
        GetComponent<Image>().useSpriteMesh = true;
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Circle") as Sprite;
        Debug.Log(GetComponent<Image>().sprite);
        Debug.Log("222");
    }
}
