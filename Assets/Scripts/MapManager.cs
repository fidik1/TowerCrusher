using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int CurrentMap { get; private set; }

    private void Awake()
    {
        CurrentMap = PlayerPrefs.GetInt("CurrentMap");
        //load scene where id = currentMap
    }
}
