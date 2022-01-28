using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFTonAR : MonoBehaviour
{
    public void Spawn(Texture texture)
    {
        var renderer = GetComponent<MeshRenderer>();
        var material = renderer.sharedMaterials[0];
        material.mainTexture = texture;
    }
}
