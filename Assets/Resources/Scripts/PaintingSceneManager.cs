using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSceneManager : MonoBehaviour
{
    public GameObject mousePainter;
    public GameObject paperFake;
    public GameObject paperReal;
    public GameObject sheetNest;

    private paintingState state;
    public enum paintingState
    {
        newsheet,
        painting
    }
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (state == paintingState.newsheet)
        {
            Debug.Log("newsheet");
        }
        if (state == paintingState.painting)
        {
            Debug.Log("painting");
        }
    }
}
