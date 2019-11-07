using System.Collections;
using System.Collections.Generic;
using SA.TB;
using UnityEngine;

public class Blashek : PlayerMove
{
        

    // Start is called before the first frame update
    void Start()
    {
        
        CharBlashek();
    }

    GameObject CharBlashek()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.AddComponent<CapsuleCollider>();
        var p = capsule.AddComponent<PlayerMove>();
        p.move = 3;
        p.moveSpeed = 4;
        //capsule.AddComponent<MouseOver>();
        capsule.AddComponent<LineRenderer>();
        capsule.transform.localPosition = new Vector3(4,2,6);
        capsule.name = "Blashek";
        capsule.transform.position = new Vector3(4, 2, 6);
        
        Vector3 pos = new Vector3(4,2,6);
        Instantiate(capsule, pos, Quaternion.identity);
        Destroy(capsule);
        return capsule;
        
        
        
        
        
    }
}
