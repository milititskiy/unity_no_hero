using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;

    public List<Tile> shortPath = new List<Tile>();
    public GameObject lineGO;
    LineRenderer line;
    GameObject currentTile;


    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = true;
        
    }

    
    private void Update()
    {
        OnMouseEnter();
        //Debug.Log(shortPath.Count);
    }


    // The mesh goes red when the mouse is over it...
    
    void OnMouseEnter()
    {
        

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit,200))
        {
            //GameObject gameObject = hit.collider.gameObject;
            TacticsMove tactics = GetComponent<TacticsMove>();
            Tile tile = hit.collider.GetComponent<Tile>();
            
            var arr = tactics.path.ToArray();
            if (hit.collider.CompareTag("Tiles"))
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                //var origin = player.transform.position;
                //Tile tile = hit.collider.GetComponent<Tile>();
                if (tile.selectable == true)
                {
                    
                    tile.selectable = false;
                    tile.hoverOn = true;
                    

                    shortPath.Clear();
                    //tile.target = true;
                    //tactics.moving = true;

                    
                    Tile next = tile;
                    var p = tile.transform.position;
                    Vector3 pos = new Vector3(p.x, 1.9F, p.z);
                    while (next != null)
                    {
                        shortPath.Add(next);
                        next = next.parent;
                        
                        //tile.transform.position = pos;
                        //Debug.Log(hit.point);

                    }
                    //line.transform.position = hit.point;
                    
                    //line.SetPosition(1,line.transform.position);
                    if (line == null)
                    {
                        GameObject go = Instantiate(lineGO,pos, Quaternion.identity) as GameObject;
                        line = go.GetComponent<LineRenderer>();

                        // line.transform.position = pos;
                        line.enabled = true;
                        Debug.Log("here true");
                        
                    }
                    else
                    {
                        line.positionCount = shortPath.Count;
                        Debug.Log("vertex");
                        for (int i = 0; i < shortPath.Count; i++)
                        {
                            
                            line.SetPosition(i, shortPath[i].transform.position);
                        }
                    }
                }

            }

            


        }


    }

    


    // ...the red fades out to cyan as the mouse is held over...
    //void OnMouseOver()
    //{
    //    renderer.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    //}

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        //GetComponent<Renderer>().material.color = Color.white;
    }
}
