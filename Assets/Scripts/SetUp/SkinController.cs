using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [Header("White")]
    public Material mat0;
    public Color col0;

    [Header("Red")]
    public Material mat1;
    public Color col1;
    [Header("Black")]
    public Material mat2;
    public Color col2;
    [Header("Dark Blue")]
    public Material mat3;
    public Color col3;
    [Header("Yellow")]
    public Material mat4;
    public Color col4;
    [Header("Light Green")]
    public Material mat5;
    public Color col5;
    [Header("Brown")]
    public Material mat6;
    public Color col6;
    [Header("Pink")]
    public Material mat7;
    public Color col7;
    [Header("Light Blue")]
    public Material mat8;
    public Color col8;
    [Header("Golden")]
    public Material mat9;
    public Color col9;

    private Material[] mats;
    private Color[] colors;

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

        colors = new Color[10];
        colors[0] = col0;
        colors[1] = col1;
        colors[2] = col2;
        colors[3] = col3; 
        colors[4] = col4;
        colors[5] = col5;
        colors[6] = col6;
        colors[7] = col7;
        colors[8] = col8;
        colors[9] = col9;
    }

    public Material[] GetMaterials(){
        return mats;
    }

    public Color[] GetColors(){
        return colors;
    }
}
