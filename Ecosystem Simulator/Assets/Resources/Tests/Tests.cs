using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Tests
{
    public class Tests : Ecosystem
    {
        public GameObject spawnedPredator;
    

        
        [UnityTest]
        public IEnumerator _Predator_Spawning_Test_From_Prefab()
        {
            var predatorPrefab = Resources.Load("Prefabs/Predator"); 

            yield return null;
            
            var spawnedPredator = GameObject.FindGameObjectsWithTag("predator");
              
            foreach(GameObject gameObject in spawnedPredator)
            {
                var prefabOfSpawnedPredator = PrefabUtility.GetCorrespondingObjectFromSource(gameObject);
                Assert.AreEqual(predatorPrefab, prefabOfSpawnedPredator);
            }
                
            
        }

        [UnityTest]
        public IEnumerator _Prey_Spawning_Test_From_Prefab()
        {

            var preyPrefab = Resources.Load("Prefabs/Prey");

            yield return null;

            var spawnedPrey = GameObject.FindGameObjectsWithTag("prey");

            foreach (GameObject gameObject in spawnedPrey)
            {
                var prefabOfSpawnedPrey = PrefabUtility.GetCorrespondingObjectFromSource(gameObject);
                Assert.AreEqual(preyPrefab, prefabOfSpawnedPrey);
            }


        }

        [UnityTest]
        public IEnumerator _Flora_Spawning_Test_From_Prefab()
        {
            var floraPrefab = Resources.Load("Prefabs/Flora");

            yield return null;

            var spawnedFlora = GameObject.FindGameObjectsWithTag("flora"); 

            foreach(GameObject gameObject in spawnedFlora)
            {
                var prefabOfSpawnedFlora = PrefabUtility.GetCorrespondingObjectFromSource(gameObject);
                Assert.AreEqual(floraPrefab, prefabOfSpawnedFlora);
            }
        }

        [UnityTest]
        public IEnumerator _FloraNutrients_Spawning_Test_From_Prefab()
        {
            var floraNutrientPrefab = Resources.Load("Prefabs/FloraNutrient");

            yield return null;

            var spawnedFloraNutrient = GameObject.FindGameObjectsWithTag("floraNutrient"); 

            foreach (GameObject gameObject in spawnedFloraNutrient)
            {
                var prefabOfSpawnedFloraNutrient = PrefabUtility.GetCorrespondingObjectFromSource(gameObject);
                Assert.AreEqual(floraNutrientPrefab, prefabOfSpawnedFloraNutrient);
            }
        }

        [UnityTest]
        public IEnumerator _FaunaNutrients_Spawning_Test_From_Prefab()
        {
            var faunaNutrientPrefab = Resources.Load("Prefabs/FaunaNutrient");

            yield return null;

            var spawnedFaunaNutrient = GameObject.FindGameObjectsWithTag("faunaNutrient");

            foreach (GameObject gameObject in spawnedFaunaNutrient)
            {
                var prefabOfSpawnedFaunaNutrient = PrefabUtility.GetCorrespondingObjectFromSource(gameObject);
                Assert.AreEqual(faunaNutrientPrefab, prefabOfSpawnedFaunaNutrient);
            }
        }


    }
}
