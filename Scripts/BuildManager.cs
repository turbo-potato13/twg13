using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class BuildManager : MonoBehaviour
{
    public Grid BuildGrid;
    public Tilemap BuildMap;
    public Tilemap TerrainMap;
    public Grid TerrainGrid;
    public Tile factory;
    public Tile res;
    public static int fabricCount = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckTerrain();
        }
    }

    private void CheckTerrain()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3Int coordinate = TerrainGrid.WorldToCell(mouseWorldPos);
        Vector3Int buildCoordinate = BuildGrid.WorldToCell(mouseWorldPos);

        if (TerrainMap.HasTile(coordinate) && BuildMap.HasTile(buildCoordinate) && BuildMap.GetTile(buildCoordinate).name == res.name)
        {
            
            BuildMap.SetTile(buildCoordinate, factory);
            fabricCount++;
        }
    }
}
