using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
