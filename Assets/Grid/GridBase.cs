using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA.TB
{
    public class GridBase : Tile
    {
        public int sizeX = 9;
        public int sizeY = 1;
        public int sizeZ = 9;
        public float scaleXZ = 2.0f;
        public float scaleY = 2.0f;

        public bool debugTile = true;
        public Material debugMaterial;

        public Tile[,,] grid;
        public List<YLevels> yLevels = new List<YLevels>();

        GameObject debugTileObj;

        private void Start()
        {
            InitPhase();
        }

        public void InitPhase()
        {
            if (debugTile)
                debugTileObj = WorldTile();
            Check();
            CreadeGrid();
        }

        void Check()
        {
            if(sizeX == 0)
            {
                Debug.Log("size x is 0 assigning min");
                sizeX = 6;
            }
            if (sizeY == 0)
            {
                Debug.Log("size y is 0 assigning min");
                sizeY = 1;
            }
            if (sizeY == 0)
            {
                Debug.Log("size z is 0 assigning min");
                sizeY = 1;
            }

            if (scaleXZ == 0)
            {
                Debug.Log("Scale xz is 0 , asiigning 1");
                scaleXZ = 1;
            }
            if (scaleY == 0)
            {
                Debug.Log("Scale Y is 0 , asiigning 2");
                scaleY = 2;
            }
        }

        void CreadeGrid()
        {
            grid = new Tile[sizeX, sizeY, sizeZ];
            for(int y = 0; y < sizeY; y++)
            {
                YLevels ylvl = new YLevels();
                ylvl.tileParent = new GameObject();
                ylvl.tileParent.name = "level" + y.ToString();
                ylvl.y = y;
                yLevels.Add(ylvl);

                //create colision

            for(int x = 0;x < sizeX; x++)
                {
                    for(int z = 0;z < sizeZ; z++)
                    {
                        Tile n = new Tile();
                        n.x = x;
                        n.y = y;
                        n.z = z;
                        n.walkable = true;
                        

                        if(debugTile)
                        {
                            Vector3 targetPosition = WorldCoordinatedFromTile(x, y, z);
                            GameObject go = Instantiate(debugTileObj,targetPosition,Quaternion.identity) as GameObject;
                            go.transform.parent = ylvl.tileParent.transform;
                            
                            

                        }

                        grid[x, y, z] = n;
                    }
                }
            }
        }
        public Tile GetWorldFromWorldPosition(Vector3 wp)
        {
            int x = Mathf.RoundToInt(wp.x / 0.9F);
            int y = Mathf.RoundToInt(wp.y / 0.9F);
            int z = Mathf.RoundToInt(wp.z / 0.9F);

            return GetTile(x, y, z);
        }

        public Tile GetTile(int x, int y, int z)
        {
            x = Mathf.Clamp(x, 0, sizeX - 1);
            y = Mathf.Clamp(x, 0, sizeY - 1);
            z = Mathf.Clamp(x, 0, sizeZ - 1);

            return grid[x, y, z];

        }

        public Vector3 WorldCoordinatedFromTile(int x, int y, int z)
        {
            Vector3 r = Vector3.zero;
            r.x = x * scaleXZ;
            r.y = y * scaleY;
            r.z = z * scaleXZ;
            return r;
        }

        GameObject WorldTile()
        {
            GameObject go = new GameObject();
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Destroy(cube.GetComponent<Collider>());
            cube.AddComponent<Tile>();
            cube.transform.parent = go.transform;
            cube.transform.localPosition = Vector3.zero;
            cube.transform.localEulerAngles = new Vector3(90, 0, 0);
            cube.name = "Tiles" + z.ToString();
            cube.tag = "Tiles";
            cube.transform.localScale = Vector3.one * 2.0f;
            cube.GetComponentInChildren<MeshRenderer>().material = debugMaterial;
           
            
            return cube;

        }

        public static GridBase singleton;
         void Awake()
        {
            singleton = this;
        }
    }

    [System.Serializable]
    public class YLevels
    {
        public int y;
        public GameObject tileParent;
        public GameObject collisionObj;

    }
}


