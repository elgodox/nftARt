using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{

    public class UriGenerator_TEST
    {

        [Test]
        public void SimpleUri()
        {
            IUrigenerator urigenerator = new UriGenerator("https://api.opensea.io/api/v1/assets");
            string _uriExpected = "https://api.opensea.io/api/v1/assets?";
            var _uriResult = urigenerator.GetUri();
            Assert.AreEqual(_uriExpected, _uriResult);

        }
        [Test]
        public void UriWithOwner()
        {
            IUrigenerator urigenerator = new UriGenerator("https://api.opensea.io/api/v1/assets?");

            string _uriExpected = "https://api.opensea.io/api/v1/assets?&owner=owner";

            urigenerator.SetOwner("owner");

            var _uriResult = urigenerator.GetUri();

            Assert.AreEqual(_uriExpected, _uriResult);

        }
        [Test]
        public void UriWithOrder()
        {
            IUrigenerator urigenerator = new UriGenerator("https://api.opensea.io/api/v1/assets?");

            string _uriExpected = "https://api.opensea.io/api/v1/assets?&order_direction=desc";

            urigenerator.SetOrderDirection("desc");

            var _uriResult = urigenerator.GetUri();

            Assert.AreEqual(_uriExpected, _uriResult);

        }

        [Test]
        public void UriWithOwnerAndOrder()
        {
            IUrigenerator urigenerator = new UriGenerator("https://api.opensea.io/api/v1/assets?");

            string _uriExpected = "https://api.opensea.io/api/v1/assets?&owner=owner&order_direction=desc";

            urigenerator.SetOrderDirection("desc");
            urigenerator.SetOwner("owner");

            var _uriResult = urigenerator.GetUri();

            Assert.AreEqual(_uriExpected, _uriResult);

        }
        [Test]
        public void UriComplete()
        {
            IUrigenerator urigenerator = new UriGenerator("https://api.opensea.io/api/v1/assets?");
            string _uriExpected = "https://api.opensea.io/api/v1/assets?&owner=owner&token_ids=token_ids&asset_contract_address=asset_contract_address&asset_contract_addresses=asset_contract_addresses&order_direction=desc&offset=0&limit=20&collection=collection";

            urigenerator.SetCollection("collection");
            urigenerator.SetLimit("20");
            urigenerator.SetOffset("0");
            urigenerator.SetOrderDirection("desc");
            urigenerator.SetAssetContractAddresses("asset_contract_addresses");
            urigenerator.SetAssetContractAddress("asset_contract_address");
            urigenerator.SetTokenIds("token_ids");
            urigenerator.SetOwner("owner");

            var _uriResult = urigenerator.GetUri();

            Assert.AreEqual(_uriExpected, _uriResult);


        }
        [Test]
        public void UriIncomplete()
        {
            IUrigenerator urigenerator = new UriGenerator("https://api.opensea.io/api/v1/assets?");
            string _uriExpected = "https://api.opensea.io/api/v1/assets?&order_direction=desc&offset=0&limit=20";
            urigenerator.SetOwner("");
            urigenerator.SetTokenIds("");
            urigenerator.SetAssetContractAddress("");
            urigenerator.SetAssetContractAddresses("");
            urigenerator.SetOrderDirection("");
            urigenerator.SetOffset("");
            urigenerator.SetLimit("");
            
            var _uriResult = urigenerator.GetUri();

            Assert.AreEqual(_uriExpected, _uriResult);
        }

    }
}

