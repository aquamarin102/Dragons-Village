using UnityEngine;
using UnityEngine.Tilemaps;

namespace Scripts.Location_Generator
{
   
   public class GeneratorLocationView : MonoBehaviour
   {
      [SerializeField] private Tilemap _tilemapGround;

      [SerializeField] private Tile _tileGround;

      [SerializeField] private int _wightMap;
      [SerializeField] private int _heightMap;

      [SerializeField] private int _factorSmooth;

      [SerializeField, Range(0, 100)] private int _randomFillPercent;

      public Tilemap TilemapGround => _tilemapGround;

      public Tile TileGround => _tileGround;

      public int WightMap => _wightMap;

      public int HeightMap => _heightMap;

      public int FactorSmooth => _factorSmooth;

      public int RandomFillPercent => _randomFillPercent;

   }
}