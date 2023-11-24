
using System.Collections.Generic;
using UnityEngine;
namespace Carvishualizer.car
{
    [CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObject/Car/CarList")]
    public class CarsSOList : ScriptableObject
    {
        public List<CarSciptableObjects> cars;
    }
}

