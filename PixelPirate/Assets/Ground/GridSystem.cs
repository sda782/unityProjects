using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelPirate.Assets.Ground
{
    public class GridSystem : MonoBehaviour
    {
        private List<Cell> cells;
        private List<Cell> unloadedCells;
        public GridSystem(int width, int height)
        {
            Width = width;
            Height = height;

            cells = new List<Cell>();
            unloadedCells = new List<Cell>();
            int index = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells.Add(new Cell(index, i, j));
                    index++;
                }
            }
            CenterCell = GetCenter();
            //GetDistToCenter(CenterCell);
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public Cell CenterCell { get; private set; }
        public List<Cell> Cells { get => cells; }

        private Cell GetCenter()
        {
            try
            {
                //return cells[(int)Math.Floor((double)(cells.Count - 1) / 2)];
                return cells.Find(c => c.X == (int)Mathf.Floor((Width / 2)) && c.Y == (int)Mathf.Floor((Height / 2)));
            }
            catch (System.Exception)
            {
                throw new System.Exception("Center not found");
            }
        }

        public void GetDistToPlayer(Cell player)
        {
            foreach (var cell in cells)
            {
                if (cell != null)
                {
                    cell.DistToPlayer = (int)Mathf.Sqrt((Mathf.Pow(player.X - cell.X, 2) + Mathf.Pow(player.Y - cell.Y, 2)));
                }
            }
        }

        public void UnloadCell(Cell cell)
        {
            //  Cell unloads and saves to a file or idk
            Debug.Log("Unload");
        }

        public void LoadCell(int index)
        {
            // Cell loads from a file
            Debug.Log("Load");
        }
    }
}