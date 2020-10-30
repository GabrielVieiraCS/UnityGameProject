using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{

    public Material mat0;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material mat5;
    public Material mat6;
    public Material mat7;
    public Material mat8;
    public Material mat9;

    private Material[] mats;

    // Start is called before the first frame update
    void Awake()
    {
        mats = new Material[10];
        mats[0] = mat0;
        mats[1] = mat1;
        mats[2] = mat2;
        mats[3] = mat3;
        mats[4] = mat4;
        mats[5] = mat5;
        mats[6] = mat6;
        mats[7] = mat7;
        mats[8] = mat8;
        mats[9] = mat9;
    }

    public Material[] GetMaterials(){
        return mats;
    }
}
