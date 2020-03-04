using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Maap : MonoBehaviour

{
    public Grid BuildGrid; 
    public Tilemap BuildMap;
    public Tilemap TerrainMap;
    public Tilemap TreeMap;
    public Grid TerrainGrid;
    public Tile res;
    public Tile grass;
    public Tile ground;
    public Tile lightGrass;
    public Tile water;
    public Tile sand;
    public Tile black;
    public Tile grey;
    public Tile tree;
    public Tile tree2;
    public Tile tree3;
    public TextMeshProUGUI price;
    
    private float tilePrice = 100f;
    // Start is called before the first frame update
    void Start()
    {


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckTerrain();
        }

        price.text = "Текущая цена расчистки: " + tilePrice;

    }

    private void CheckTerrain()
    {
        int usl = Random.Range(0, 100);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3Int coordinate = TerrainGrid.WorldToCell(mouseWorldPos);
        Vector3Int buildCoordinate = BuildGrid.WorldToCell(mouseWorldPos);

        if (usl < 40 && TerrainMap.HasTile(coordinate) && TerrainMap.GetTile(coordinate).name == grey.name && MoneyManager.Money > tilePrice)
        {
            gameManager.MaxUnits += 0.5f;
            int usl1 = Random.Range(0, 100);
            if (usl1 < 70){
                TerrainMap.SetTile(coordinate, grass);
                if (usl < 3) 
                {
                    TreeMap.SetTile(coordinate, tree);
                }
            }
            else if (70 <= usl1 && usl1 < 85)
            {
                TerrainMap.SetTile(coordinate, ground);
                if (usl < 73)
                {
                    TreeMap.SetTile(coordinate, tree2);
                }
            }
            else if (85 <= usl1 && usl1 < 100)
            {
                TerrainMap.SetTile(coordinate, lightGrass);
                if (usl < 88)
                {
                    TreeMap.SetTile(coordinate, tree3);
                }
            }
            Vector3Int coord = (new Vector3Int(coordinate.x - 1, coordinate.y, coordinate.z));
            if ( TerrainMap.GetTile(coord).name == black.name)
            {
                TerrainMap.SetTile(coord, grey);
            }
            Vector3Int coord1 = (new Vector3Int(coordinate.x + 1, coordinate.y, coordinate.z));
            if ( TerrainMap.GetTile(coord1).name == black.name)
            {
                TerrainMap.SetTile(coord1, grey);
            }
            Vector3Int coord2 = (new Vector3Int(coordinate.x, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord2).name == black.name)
            {
                TerrainMap.SetTile(coord2, grey);
            }
            Vector3Int coord3 = (new Vector3Int(coordinate.x + 1, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord3).name == black.name)
            {
                TerrainMap.SetTile(coord3, grey);
            }
            Vector3Int coord4 = (new Vector3Int(coordinate.x, coordinate.y - 1, coordinate.z));
            if ( TerrainMap.GetTile(coord4).name == black.name)
            {
                TerrainMap.SetTile(coord4, grey);
            }
            Vector3Int coord5 = (new Vector3Int(coordinate.x + 1, coordinate.y - 1, coordinate.z));
            if ( TerrainMap.GetTile(coord5).name == black.name)
            {
                TerrainMap.SetTile(coord5, grey);
            }
            Vector3Int coord6 = (new Vector3Int(coordinate.x - 1, coordinate.y - 1, coordinate.z));
            if (TerrainMap.GetTile(coord6).name == black.name)
            {
                TerrainMap.SetTile(coord6, grey);
            }
            Vector3Int coord7 = (new Vector3Int(coordinate.x - 1, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord7).name == black.name)
            {
                TerrainMap.SetTile(coord7, grey);
            }
            if (usl == 23 || usl == 6 || usl == 11 || usl == 32)
                BuildMap.SetTile(buildCoordinate, res);
            MoneyManager.Money -= tilePrice;
            MoneyManager.income += 10f;
            gameManager.score += 100f;
            tilePrice += 25f;
        }
        else if (40 <= usl && usl < 70 && TerrainMap.HasTile(coordinate) && TerrainMap.GetTile(coordinate).name == grey.name && MoneyManager.Money > tilePrice)
        {
            gameManager.MaxUnits += 0.3f;
            TerrainMap.SetTile(coordinate, water);
            Vector3Int coord = (new Vector3Int(coordinate.x - 1, coordinate.y, coordinate.z));
            if (TerrainMap.GetTile(coord).name == black.name)
            {
                TerrainMap.SetTile(coord, grey);
            }
            Vector3Int coord1 = (new Vector3Int(coordinate.x + 1, coordinate.y, coordinate.z));
            if (TerrainMap.GetTile(coord1).name == black.name)
            {
                TerrainMap.SetTile(coord1, grey);
            }
            Vector3Int coord2 = (new Vector3Int(coordinate.x, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord2).name == black.name)
            {
                TerrainMap.SetTile(coord2, grey);
            }
            Vector3Int coord3 = (new Vector3Int(coordinate.x + 1, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord3).name == black.name)
            {
                TerrainMap.SetTile(coord3, grey);
            }
            Vector3Int coord4 = (new Vector3Int(coordinate.x, coordinate.y - 1, coordinate.z));
            if (TerrainMap.GetTile(coord4).name == black.name)
            {
                TerrainMap.SetTile(coord4, grey);
            }
            Vector3Int coord5 = (new Vector3Int(coordinate.x + 1, coordinate.y - 1, coordinate.z));
            if (TerrainMap.GetTile(coord5).name == black.name)
            {
                TerrainMap.SetTile(coord5, grey);
            }
            Vector3Int coord6 = (new Vector3Int(coordinate.x - 1, coordinate.y - 1, coordinate.z));
            if (TerrainMap.GetTile(coord6).name == black.name)
            {
                TerrainMap.SetTile(coord6, grey);
            }
            Vector3Int coord7 = (new Vector3Int(coordinate.x - 1, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord7).name == black.name)
            {
                TerrainMap.SetTile(coord7, grey);
            }
            MoneyManager.Money -= tilePrice;
            MoneyManager.income += 8;
            gameManager.score += 100f;
            tilePrice +=25f;

        }
        else if (70 <= usl && usl < 100 && TerrainMap.HasTile(coordinate) && TerrainMap.GetTile(coordinate).name == grey.name && MoneyManager.Money > tilePrice)
        {
            TerrainMap.SetTile(coordinate, sand);
            Vector3Int coord = (new Vector3Int(coordinate.x - 1, coordinate.y, coordinate.z));
            if (TerrainMap.GetTile(coord).name == black.name)
            {
                TerrainMap.SetTile(coord, grey);
            }
            Vector3Int coord1 = (new Vector3Int(coordinate.x + 1, coordinate.y, coordinate.z));
            if (TerrainMap.GetTile(coord1).name == black.name)
            {
                TerrainMap.SetTile(coord1, grey);
            }
            Vector3Int coord2 = (new Vector3Int(coordinate.x, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord2).name == black.name)
            {
                TerrainMap.SetTile(coord2, grey);
            }
            Vector3Int coord3 = (new Vector3Int(coordinate.x + 1, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord3).name == black.name)
            {
                TerrainMap.SetTile(coord3, grey);
            }
            Vector3Int coord4 = (new Vector3Int(coordinate.x, coordinate.y - 1, coordinate.z));
            if (TerrainMap.GetTile(coord4).name == black.name)
            {
                TerrainMap.SetTile(coord4, grey);
            }
            Vector3Int coord5 = (new Vector3Int(coordinate.x + 1, coordinate.y - 1, coordinate.z));
            if (TerrainMap.GetTile(coord5).name == black.name)
            {
                TerrainMap.SetTile(coord5, grey);
            }
            Vector3Int coord6 = (new Vector3Int(coordinate.x - 1, coordinate.y - 1, coordinate.z));
            if (TerrainMap.GetTile(coord6).name == black.name)
            {
                TerrainMap.SetTile(coord6, grey);
            }
            Vector3Int coord7 = (new Vector3Int(coordinate.x - 1, coordinate.y + 1, coordinate.z));
            if (TerrainMap.GetTile(coord7).name == black.name)
            {
                TerrainMap.SetTile(coord7, grey);
            }
            if (usl == 77 || usl == 93)
                BuildMap.SetTile(buildCoordinate, res);
            MoneyManager.Money -= tilePrice;
            MoneyManager.income += 5f;
            gameManager.score += 100f;
            tilePrice += 25f;
            
        }
    }
}

