using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Tests
{

    public class RestManager_TEST
    {
        public Action<Asset> OnObtainNFT;

        [Test(ExpectedResult =null)]
        public IEnumerator GetDataFromWeb_Test()
        {
            UnityWebRequest www = UnityWebRequest.Get("https://api.opensea.io/api/v1/assets?order_direction=desc&offset=0&limit=20");
            www.SetRequestHeader("Accept", "application/json");
            www.SetRequestHeader("X-API-KEY", "ede9cdaa66d0421c995acc00fb40ec77");
            

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Assert.Fail();
            }
            else
            {
                var deserializer = new NFTJsonDeserializer();
                var rData = deserializer.Deserialize(www.downloadHandler.text);
                Assert.AreEqual(20, rData.assets.Count);
                foreach (var item in rData.assets)
                {
                    Assert.IsNotNull(item);
                }
            }
            yield return null;
        }

    }

}
