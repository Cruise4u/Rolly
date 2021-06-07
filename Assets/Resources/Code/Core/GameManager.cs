using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public override void Awake()
    {
        base.Awake();
        Screen.orientation = ScreenOrientation.Landscape;
    }


}

