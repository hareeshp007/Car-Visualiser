using Cinemachine;
using UnityEngine;
namespace Carvishualizer.camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private CinemachineFreeLook m_Camera;
        [SerializeField] private CinemachineFreeLook.Orbit[] originalOrbits;
        [SerializeField]
        private CinemachineFollowZoom followZoom;
        [SerializeField]
        private Transform carModel;
        public float rotationSpeed = 2f;
        public float panSpeed = 2f;
        public float zoomSpeed = 2f;
        [SerializeField]
        private float zoom;
        [SerializeField]
        private float verticalPan;
        [SerializeField]
        private float horizontalPan;
        [SerializeField]
        private bool autoRotateOn;
        [SerializeField]
        private bool YmaxValueReached;
        [SerializeField]
        private float zoomValue = 4;
        private bool upperConstraint;
        private bool lowerConstaint;

        private void Start()
        {
            followZoom = GetComponent<CinemachineFollowZoom>();
            m_Camera = GetComponent<CinemachineFreeLook>();
            carModel = m_Camera.LookAt;
            originalOrbits = new CinemachineFreeLook.Orbit[m_Camera.m_Orbits.Length];
            for (int i = 0; i < m_Camera.m_Orbits.Length; i++)
            {
                originalOrbits[i].m_Height = m_Camera.m_Orbits[i].m_Height;
                originalOrbits[i].m_Radius = m_Camera.m_Orbits[i].m_Radius;
            }
        }
        void Update()
        {
            autoRotate();
            checkInput();
            ZoomCamera();
            changeRotation();
        }

        private void checkInput()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                autoRotateOn = false;
            }

        }

        private void changeRotation()
        {
            if (m_Camera.m_YAxis.Value >= .9f || m_Camera.m_YAxis.Value <= 0.1)
            {
                Debug.Log("change Rotation");
                verticalPan *= -1;
            }
        }

        void ZoomCamera()
        {
            zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            UpdateOrbit(zoom);
            //followZoom.m_Width = Mathf.Clamp(followZoom.m_Width - zoom, followZoom.m_MinFOV, followZoom.m_MaxFOV); ;
        }
        public void UpdateOrbit(float zoomPercent)
        {

            for (int i = 0; i < m_Camera.m_Orbits.Length; i++)
            {
                checkCameraZoomConstrains(i);
                if (!upperConstraint)
                {
                    SetToUpperConstaint(i);
                }
                else if (!lowerConstaint)
                {
                    setToLowerConstraint(i);
                }
                else if (checkCameraZoomConstrains(i))
                {
                    SetCamera(zoomPercent, i);
                }
            }
        }

        private void SetToUpperConstaint(int i)
        {
            m_Camera.m_Orbits[i].m_Height = originalOrbits[i].m_Height * zoomValue;
            m_Camera.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius * zoomValue;
        }

        private void setToLowerConstraint(int i)
        {
            m_Camera.m_Orbits[i].m_Height = originalOrbits[i].m_Height / 2;
            m_Camera.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius / 2;
        }

        private void SetCamera(float zoomPercent, int i)
        {
            m_Camera.m_Orbits[i].m_Height += originalOrbits[i].m_Height * -zoomPercent * Time.deltaTime;
            m_Camera.m_Orbits[i].m_Radius += originalOrbits[i].m_Radius * -zoomPercent * Time.deltaTime;
        }

        private bool checkCameraZoomConstrains(int i)
        {
            upperConstraint = (m_Camera.m_Orbits[i].m_Height <= originalOrbits[i].m_Height * zoomValue ||
                    m_Camera.m_Orbits[i].m_Radius <= originalOrbits[i].m_Radius * zoomValue);
            lowerConstaint = (m_Camera.m_Orbits[i].m_Height >= originalOrbits[i].m_Height / 2 ||
                    m_Camera.m_Orbits[i].m_Radius >= originalOrbits[i].m_Radius / 2);
            return (upperConstraint && lowerConstaint);
        }
        private void autoRotate()
        {
            if (autoRotateOn)
            {
                m_Camera.m_XAxis.Value += horizontalPan * m_Camera.m_XAxis.m_MaxValue * Time.deltaTime;
                m_Camera.m_YAxis.Value += verticalPan * Time.deltaTime;
            }
        }
        public void SetAutoRotation()
        {
            Debug.Log("Rotation");
            autoRotateOn = !autoRotateOn;
        }


    }
}