using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{

    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;
        public Ray mouseRay;
        public RaycastHit2D hit; 
        public Tile hitTile;
        public int adjacentMines;

        // Functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            //Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; //position tile
            Tile currentTile = clone.GetComponent<Tile>(); // Get Tile Component\
            return currentTile; // return it
        }

        void GenerateTiles()
        {
            // Create new 2d array of size width x height
            tiles = new Tile[width, height];

            //loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);

                    //Pivot tiles around grid
                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);

                    //Apply spacing
                    pos *= spacing;

                    //Spawn the tile
                    Tile tile = SpawnTile(pos);
                    //Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    //Store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    tiles[x, y] = tile;
                }
            }
        }

        private void Start()
        {
            //Generate tiles on startup
            GenerateTiles();
        }

        public int GetAdjacentMineCount(Tile tile)
        {
            // Set count to 0
            int count = 0;
            // loop though all adjacent tiles on the X
            for (int x = -1; x <= 1; x++)
            {
                // Loop though all adjacent tiles on the Y
                for (int y = -1; y <= 1; y++)
                {
                    //Calculate which adjacent tile to look at
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;

                    //check if that tile is a mine

                    if(desiredX >= 0 && desiredX < tiles.GetLength(0))
                    {
                        if (desiredY >= 0 && desiredY < tiles.GetLength(1))
                        {
                            //select current tile
                            Tile currentTile = tiles[desiredX, desiredY];
                            if (currentTile.isMine)
                            {
                                //Increment count by 1
                                count++;
                            }
                        }
                    }

                    
                }
            }
            // remember to return the count!
            return count;
        }

        void Update()
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            if (hit.collider != null)
            {
                Tile hitTile = hit.collider.GetComponent<Tile>();
                if (hitTile != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        int adjacentMines = GetAdjacentMineCount(hitTile);
                        hitTile.reveal(adjacentMines);
                    }
                }
            }
        }
    }
}