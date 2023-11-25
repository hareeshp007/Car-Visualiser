
using UnityEngine;

namespace Carvishualizer.UI
{
    public class UImanager : MonoBehaviour
    {
        public GameObject CarColorPicker;
        public GameObject CarWindowColorPicker;
        public void CarColorPallete()
        {
            if (CarColorPicker.activeInHierarchy)
            {
                CarColorPicker.SetActive(false);
            }
            else
            {
                CarColorPicker.SetActive(true);
            }
        }
        public void CarWindowColorPallete()
        {
            if (CarWindowColorPicker.activeInHierarchy)
            {
                CarWindowColorPicker.SetActive(false);
            }
            else
            {
                CarWindowColorPicker.SetActive(true);
            }
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}