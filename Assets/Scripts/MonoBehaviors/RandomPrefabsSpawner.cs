using System;
using Assets.Scripts.Base;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors
{
    public class RandomPrefabsSpawner : MonoBehaviour, ISpawner<GameObject>
    {
        private IRandomProvider<GameObject> _randomItemProvider;

        [SerializeField]
        private GameObject[] Prefabs;

        [SerializeField]
        private bool ShouldActivateOnCreation;

        private void Awake()
        {
            _randomItemProvider = new RandomItemProvider<GameObject>(Prefabs);
        }

        public GameObject Spawn()
        {
            var randomItem = _randomItemProvider.GetRandom();
            var spawnedItem = Instantiate(randomItem, transform.position, Quaternion.identity);
            spawnedItem.SetActive(ShouldActivateOnCreation);

            return spawnedItem;
        }
    }
}
