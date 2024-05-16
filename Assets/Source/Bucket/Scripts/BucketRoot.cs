using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(BucketMaterialBarFactory))]
    [RequireComponent(typeof(BucketPresenter))]
    public class BucketRoot : Root
    {
        private Bucket _bucket;
        private BucketPresenter _bucketPresenter;
        private BucketMaterialBarFactory _barFactory;

        public override void Compose()
        {
            _barFactory = GetComponent<BucketMaterialBarFactory>();
            _bucketPresenter = GetComponent<BucketPresenter>();
            _bucket = new Bucket();
            _bucketPresenter.Init(_bucket);
            BucketMaterialBarPresenter bucketMaterialBar = _barFactory.Create(transform);
            bucketMaterialBar.Init(_bucket);
        }
    }
}
