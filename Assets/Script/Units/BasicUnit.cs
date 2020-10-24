﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicUnit : Unit
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

        GetComponent<Image>().sprite = Resources.Load<Sprite>("Square");
    }
}
