using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverTextura : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.1f;
    [SerializeField]
    private ejes ejemovimiento;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveThis = Time.time * scrollSpeed;
        switch (ejemovimiento) {
            case ejes.y:
                rend.material.SetTextureOffset("_MainTex", new Vector2(0, moveThis));
                break;
            case ejes.x:
                rend.material.SetTextureOffset("_MainTex", new Vector2(moveThis, 0));
                break;
            case ejes.yn:
                rend.material.SetTextureOffset("_MainTex", new Vector2(0, -moveThis));
                break;
            case ejes.xn:
                rend.material.SetTextureOffset("_MainTex", new Vector2(-moveThis,0));
                break;
        }
        
        
    }

    
}
public enum ejes {
        x,y,xn,yn,z,zn
    }