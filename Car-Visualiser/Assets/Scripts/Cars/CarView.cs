
using UnityEngine;
namespace Carvishualizer.car
{
    public class CarView : MonoBehaviour
    {
        public Material CarMaterial;
        public Material CarWindow;
        [SerializeField]
        private Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        public void SetColorCar(Color color)
        {
            CarMaterial.color = color;
        }
        public void SetColorCarWindow(Color color)
        {
            CarWindow.color = color;
        }

        public void AniamtionCar()
        {
            animator.SetTrigger("AnimationButtonOn");
        }
    }
}