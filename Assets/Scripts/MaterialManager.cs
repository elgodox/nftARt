using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _imageNFT;
    [SerializeField]
    private NFTonAR _objectToShowOnAR;
    [SerializeField]
    private Texture _spawnedMaterial;
    [SerializeField]
    private Texture _texture;
    public void AssignMaterial()
    {
        
        var a = _imageNFT.GetComponents<RawImage>();
        foreach (var item in a)
        {
            _texture = item.texture;
        }
        AssignTexture();
    }

    private void AssignTexture()
    {
        if (_texture != null)
        {
            _objectToShowOnAR = Resources.Load<NFTonAR>("Prefabs/SpawnedNFT");
            _objectToShowOnAR.Spawn(_texture);
            StartCoroutine(LoadSceneAR());
        }
    }


    IEnumerator LoadSceneAR()
    {
        yield return SceneManager.LoadSceneAsync("SimpleAR", LoadSceneMode.Additive);
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
