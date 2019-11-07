using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SA.TB
{

    public class GManager : MonoBehaviour
    {
        public Transform curUnit;
        public PlayerMove player;
        bool hasPath;

        Tile unitTile;
        Tile curTile;
        Tile prevTile;

        List<Tile> path;

        LineRenderer pathVis;
        GridBase grid;


        public void Init()
        {

            grid = GridBase.singleton;
            Vector3 worldPos = grid.GetWorldCoordinatesFromTile(2, 2 / 2, 4);
            curUnit.transform.position = worldPos;

            GameObject go = new GameObject();
            go.name = "line vis";
            pathVis = go.AddComponent<LineRenderer>();
            pathVis.startWidth = 0.2f;
            pathVis.endWidth = 0.2f;
        }

        void FindTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                curTile = GridBase.singleton.GetTileFromWorldPosition(hit.point);
            }
        }
        public static GManager singleton;

        private void Awake()
        {
            singleton = this;
        }

        private void Update()
        {
            if (GridBase.singleton.isInit == false)
                return;

            FindTile();
            if(unitTile == null && curUnit != null)
            {
                //unitTile = grid.GetTileFromWorldPosition(curUnit.transform.position);
            }
            if (unitTile == null)
                return;

            if(prevTile != curTile)
            {
               //PathfindMaster.GetInstance().RequestPathFind(unitTile,curTile,PathFinderCallback);

            }

            prevTile = curTile;

            if(hasPath && path != null)
            {
                if(path.Count > 0)
                {
                    pathVis.positionCount = path.Count;

                    for (int i = 0; i < path.Count; i++)
                    {

                        Tile n = path[i];
                        Vector3 p = grid.GetWorldCoordinatesFromTile(n.x, n.y, n.z);
                        pathVis.SetPosition(i, p);
                    }
                }
            }
        }

        void PathFinderCallback(List<Tile> p)
        {
            path = p;
            hasPath = true;
        }
    }


}
