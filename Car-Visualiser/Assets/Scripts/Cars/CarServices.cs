using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarServices : MonoBehaviour
{
    public CarsSOList CarList;
    public List<GameObject> cars;
    public Transform position;
    private GameObject CurrentCar;

    private void Awake()
    {
        CreateCar();
    }
    private void CreateCar()
    {
        //int i = Random.Range(0, CarList.cars.Count);
        for(int j = 0; j < CarList.cars.Count; j++)
        {
            GameObject car = GameObject.Instantiate(CarList.cars[j].CarPrefab, position);
            cars.Add(car);
            car.SetActive(false);
        }
        CurrentCar = cars[0];
        CurrentCar.SetActive(true);
    }
    public void SetCar(TMP_Dropdown dropdown)
    {
        int i = dropdown.value;
        if(CurrentCar == null)
        {
            CurrentCar = cars[i];
        }
        else
        {
            CurrentCar.SetActive(false);
            CurrentCar = cars[i];
            CurrentCar.SetActive(true);
        }
    }
    public void SetCarColor(FlexibleColorPicker colors)
    {
        
        CurrentCar.gameObject.GetComponent<CarView>().SetColorCar(colors.color);
    }
    public void SetCarWindowColor(FlexibleColorPicker colors)
    {
        CurrentCar.gameObject.GetComponent<CarView>().SetColorCarWindow(colors.color);
    }
}
