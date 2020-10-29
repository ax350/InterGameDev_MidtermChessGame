using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public BoardGenerator gameBoard;
    public UnitManager gameUnitManager;
    public SoundManager gameSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        /*
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DontDestroyOnLoad(singleton);
        }
        */
        gameSoundManager.SetupSoundManager();
        gameBoard.MakeBoard();
        gameUnitManager.SetupUnits(gameBoard);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DoWait(float time)
    {
        StartCoroutine(Wait(time));
    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
