

using Carvishualizer.essentials;
using Carvishualizer.Sound;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Carvishualizer.car
{
    public class CarServices : MonoSingletonGeneric<CarServices>
    {
        public CarsSOList CarList;
        public List<GameObject> cars;
        public List<AudioClip> carAudios;
        public Transform position;
        private GameObject CurrentCar;
        [SerializeField]
        private int CurrentValue;

        private void Awake()
        {
            base.Awake();
            CreateCar();
        }
        private void CreateCar()
        {
            //int i = Random.Range(0, CarList.cars.Count);
            for (int j = 0; j < CarList.cars.Count; j++)
            {
                GameObject car = GameObject.Instantiate(CarList.cars[j].CarPrefab, position);
                cars.Add(car);
                carAudios.Add(CarList.cars[j].CarClip);
                car.SetActive(false);
            }
            CurrentCar = cars[0];
            CurrentCar.SetActive(true);
        }
        public void SetCar(TMP_Dropdown dropdown)
        {
            SoundManager.Instance.StopEffect();
            CurrentValue = dropdown.value;
            if (CurrentCar == null)
            {
                CurrentCar = cars[CurrentValue];
            }
            else
            {
                CurrentCar.SetActive(false);
                CurrentCar = cars[CurrentValue];
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
        public void StartSoundFX()
        {
            SoundManager.Instance.PlayAudio(carAudios[CurrentValue]);
        }
    }
}