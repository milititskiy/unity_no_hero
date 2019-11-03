using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : Tile
{
    
    Ray ray;
    RaycastHit hit;
    private LayerMask TilesLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            
            if (hit.collider.tag == "Tiles")
            {
                //Debug.Log("Tiles are set");
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile.selectable == true)
                {
                    
                    
                    Debug.Log("isSelectable");
                    tile.GetComponent<Renderer>().material.color = Color.grey;
                    

                }
                else
                {
                    tile.GetComponent<Renderer>().material.color = Color.blue;

                }
                
                
                
            }




        }
    }


    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        //renderer.material.color = Color.black;
        
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    GameObject gameObject = hit.collider.gameObject;
        //    if(hit.collider.tag == "Tiles")
        //    {
        //        //Debug.Log("Tiles are set");
        //        Tile tile = hit.collider.GetComponent<Tile>();
        //        if (tile.selectable)
        //        {
        //            hit.collider.GetComponent<Tile>().selectable = false;
        //            //tile.hoverOn = true;
                    
        //            Debug.Log("isSelectable");
        //            //tile.GetComponent<Renderer>().material.color = Color.cyan;
        //            //GetComponent<Renderer>().material.color = Color.clear;
        //            GetComponent<Renderer>().material.color = Color.blue;

        //        }
        //        //GetComponent<MeshRenderer>().material.color = Color.clear; 
        //        //renderer.material.color = Color.yellow;
        //    }
            
            
            
            
        //}


    }

    // ...the red fades out to cyan as the mouse is held over...
    //void OnMouseOver()
    //{
    //    renderer.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    //}

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
