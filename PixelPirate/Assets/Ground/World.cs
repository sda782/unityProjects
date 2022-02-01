using System;
using System.Collections;
using System.Collections.Generic;
using PixelPirate.Assets.Ground;
using UnityEngine;

public class World : MonoBehaviour
{

    [SerializeField]
    private GameObject groundPreFab;
    private GridSystem grid;
    [SerializeField]
    public Player player;
    [SerializeField]
    private int WorldSize;

    public GridSystem Grid { get => grid; }
    void Start()
    {
        grid = new GridSystem(WorldSize, WorldSize);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        //player = new Player();
        player.Position = new Cell(0, 0, 0);
        grid.GetDistToPlayer(player.Position);
        SpawnWorld();
    }

    public void UpdateWorld()
    {
        grid.GetDistToPlayer(player.Position);
        foreach (Cell cell in grid.Cells)
        {
            if (cell.DistToPlayer > 1 && cell.GroundPreFab.activeSelf)
            {
                cell.GroundPreFab.SetActive(false);
                Debug.Log("InActive objects");
            }
            else if (cell.DistToPlayer <= 1 && !cell.GroundPreFab.activeSelf)
            {
                cell.GroundPreFab.SetActive(true);
                cell.Resources = GetRESOURCE();
                cell.GroundPreFab.GetComponentInChildren<TextMesh>().text = cell.Resources.ToString();
                Debug.Log("Active objects");
            }
        }
    }

    private void SpawnWorld()
    {

        foreach (Cell cell in grid.Cells)
        {
            cell.GroundPreFab = Instantiate(groundPreFab, new Vector3(cell.X * 20, cell.Y * 20, 0), Quaternion.identity);
            cell.GroundPreFab.transform.SetParent(gameObject.transform);
            if (cell == grid.CenterCell)
            {
                cell.Resources = Resources.RESOURCES.CRAFTING;
            }
            else
            {
                cell.Resources = GetRESOURCE();
            }
            cell.GroundPreFab.GetComponentInChildren<TextMesh>().text = cell.Resources.ToString();
            if (cell.DistToPlayer > 3)
            {
                cell.GroundPreFab.SetActive(false);
            }
        }
    }

    public string GetResourceFromPlayerPos()
    {
        return grid.Cells.Find(c => c.Index == player.Position.Index).Resources.ToString();
    }
    private Resources.RESOURCES GetRESOURCE()
    {
        return (Resources.RESOURCES)Resources.RESOURCES.GetValues(typeof(Resources.RESOURCES)).GetValue(UnityEngine.Random.Range(0, Resources.RESOURCES.GetValues(typeof(Resources.RESOURCES)).Length - 1));
    }
}
