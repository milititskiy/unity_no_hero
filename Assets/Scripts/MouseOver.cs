using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    
    Ray ray;
    RaycastHit hit;
    private LayerMask TilesLayer;
    
   

    private void Update()
    {
        OnMouseEnter();
    }


    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject gameObject = hit.collider.gameObject;
            if (hit.collider.CompareTag("Tiles"))
            {
                Debug.Log("debug");
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile.selectable == true)
                {
                    hit.collider.GetComponent<Tile>().selectable = false;
                    hit.collider.GetComponent<Tile>().hoverOn = true;
                   
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
