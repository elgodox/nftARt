using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NFT : MonoBehaviour
{

    public void OnInstance(NFTData nftData, Transform position)
    {
        Image image = GetComponent<Image>();
        Material material = new Material(Shader.Find("Unlit/Texture"));
        material.name = nftData.id;
        material.mainTexture = nftData.texture;
        image.material = material;
        Instantiate(this, position);
    }

}
