using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA.TB
{
    public class GridBase : Tile
    {
        public bool isInit;
        public int sizeX = 9;
        public int sizeY = 1;
        public int sizeZ = 9;
        public float scaleXZ = 2.0f;
        //public float scaleXZ = 0.5f;
        public float scaleY = 2.3f;

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
            CreateGrid();

            //GManager.singleton.Init();
            MouseOver.singleton.Init();
            isInit = true;
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

        void CreateGrid()
        {
            grid = new Tile[sizeX, sizeY, sizeZ];
            for(int y = 0; y < sizeY; y++)
            {
                YLevels ylvl = new YLevels();
                ylvl.tileParent = new GameObject();
                ylvl.tileParent.name = "level" + y.ToString();
                ylvl.y = y;
                yLevels.Add(ylvl);

                CreateCollision(y);

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
                            Vector3 targetPosition = GetWorldCoordinatesFromTile(x, y, z);
                            GameObject go = Instantiate(debugTileObj,targetPosition,Quaternion.identity) as GameObject;
                            go.transform.parent = ylvl.tileParent.transform;
                            go.SetActive(true);
                            

                        }

                        grid[x, y, z] = n;
                    }
                }
            }
        }

        void CreateCollision(int y)
        {
            YLevels lvl = yLevels[y];
            GameObject go = new GameObject();
            BoxCollider box = go.AddComponent<BoxCollider>();
            box.size = new Vector3(sizeX * sizeY + (scaleXZ * 2),
                0.2f, sizeZ + (scaleXZ * 2));
            box.transform.position = new Vector3((sizeX * scaleXZ) * .5f - (scaleXZ * .5f),
                y * scaleY, (sizeZ * scaleXZ) * 0.5f - (scaleXZ * .5f));

            lvl.collisionObj = go;
            lvl.collisionObj.name = "lvl" + y + "collision";
        }
        public Tile GetTileFromWorldPosition(Vector3 wp)
        {
            int x = Mathf.RoundToInt(wp.x / scaleXZ);
            int y = Mathf.RoundToInt(wp.y / scaleY);
            int z = Mathf.RoundToInt(wp.z / scaleXZ);

            return GetTile(x, y, z);
        }

        public Tile GetTile(int x, int y, int z)
        {
            x = Mathf.Clamp(x, 0, sizeX - 1);
            y = Mathf.Clamp(x, 0, sizeY - 1);
            z = Mathf.Clamp(x, 0, sizeZ - 1);

            return grid[x, y, z];

        }

        public Vector3 GetWorldCoordinatesFromTile(int x, int y, int z)
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
            go.SetActive(false);
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


