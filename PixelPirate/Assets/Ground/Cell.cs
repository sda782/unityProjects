using UnityEngine;

namespace PixelPirate.Assets.Ground
{
    public class Cell
    {
        public Cell(int index, int x, int y)
        {
            Index = index;
            X = x;
            Y = y;
        }
        public int Index { get; set; }
        public int DistToPlayer { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public GameObject GroundPreFab { get; set; }
        public Resources.RESOURCES Resources { get; set; }
        public void UpdateXY(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}