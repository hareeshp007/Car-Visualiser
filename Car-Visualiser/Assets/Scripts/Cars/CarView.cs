
using UnityEngine;
namespace Carvishualizer.car
{
    public class CarView : MonoBehaviour
    {
        public Material CarMaterial;
        public Material CarWindow;
        public void SetColorCar(Color color)
        {
            CarMaterial.color = color;
        }
        public void SetColorCarWindow(Color color)
        {
            CarWindow.color = color;
        }
    }
}