
using UnityEngine;
namespace Carvishualizer.car
{
    [CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObject/Car/NewCar")]
    public class CarSciptableObjects : ScriptableObject
    {
        public GameObject CarPrefab;
        public AudioClip CarClip;

    }
}
