using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class ElectronRing : MonoBehaviour
    {
        public float speed = 10f;
        public float ringSpan = 0;
        private ElectronRingRotationTypes prevRotationType = ElectronRingRotationTypes.Rotation2D;
        public ElectronRingRotationTypes currentRotationType = ElectronRingRotationTypes.Rotation2D;

        // Each ring with its individual electrons
        private List<GameObject> _rings = new List<GameObject>();

        private void Update()
        {
            if (currentRotationType != prevRotationType)
            {
                SwitchElectronRingRotationType(currentRotationType);
                prevRotationType = currentRotationType;
            }
        }

        /// <summary>
        /// Generates the electron rings of an atom. Made with use of atom class in mind.
        /// </summary>
        /// <param name="electrons">The number of electrons there are.</param>
        /// <param name="start">Start radius of first ring.</param>
        /// <returns></returns>
        public GameObject GenerateElectronRings(int electrons, float start)
        {
            // Creating the container object
            GameObject model = new GameObject("ElectronRings");
            model.transform.parent = this.transform;
            model.transform.localPosition = Vector3.zero;

            uint ring = 1;
            float ringDist = 0;
            float electron = 0;
            GameObject tmp = new GameObject($"ElectronRing{ring}");
            tmp.transform.parent = model.transform;

            // Generating ring
            tmp.AddComponent<Torus>();
            tmp.GetComponent<Torus>().GenerateTorus(this.transform.position, start, 0.2f);

            tmp.transform.localPosition = Vector3.zero;
            _rings.Add(tmp);

            // Generating individual electrons
            bool allElectrons = true; float amountNeeded = 0;
            List<GameObject> elecs = new List<GameObject>();
            for ( int i = 0; i < electrons; i++ )
            {
                float amountOfElectrons;
                if (allElectrons)
                    amountOfElectrons = 2 * (Mathf.Pow(ring, 2));
                else
                    amountOfElectrons = amountNeeded;

                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = $"Electron{electron}";
                sphere.transform.parent = _rings[(int)ring - 1].transform;
                sphere.transform.localPosition = new Vector3(start + ringDist, 0, 0);
                sphere.transform.RotateAround(this.transform.position, Vector3.up, (360 / amountOfElectrons) * electron);
                sphere.GetComponent<MeshRenderer>().material.color = Color.yellow;

                elecs.Add(sphere);
                electron++;

                if (electron == amountOfElectrons && i < electrons - 1)
                {
                    float a = electrons - (i + 1);
                    float b = 2 * Mathf.Pow(ring + 1, 2);
                    if (a < b)
                    {
                        allElectrons = false;
                        amountNeeded = a;
                    }

                    electron = 0;
                    ring++;
                    ringDist += 1;

                    GameObject tmpa = new GameObject($"ElectronRing{ring}");
                    tmpa.transform.parent = model.transform;

                    tmpa.AddComponent<Torus>();
                    tmpa.GetComponent<Torus>().GenerateTorus(this.transform.position, start + ringDist, 0.2f, 32 * ring, 12 * ring);

                    tmpa.transform.localPosition = Vector3.zero;

                    _rings.Add(tmpa);
                }
            }

            ringSpan = ringDist;

            return model;
        }

        /// <summary>
        /// Switches the rotation type of an atomic model's electron rings
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns>Returns a boolean based on if it was success</returns>
        public void SwitchElectronRingRotationType(ElectronRingRotationTypes type)
        {
            if(type == ElectronRingRotationTypes.Rotation2D)
            {
                for (int i = 0; i < _rings.Count; i++)
                {
                    Vector3 rot = _rings[i].transform.rotation.eulerAngles; rot.x = 0;
                    StartCoroutine(rotateRing(_rings[i], Quaternion.Euler(rot)));
                }
            }
            else
            {
                for (int i = 0; i < _rings.Count; i++)
                {
                    Vector3 rot = _rings[i].transform.localRotation.eulerAngles; rot.x = i * (180 / _rings.Count);
                    StartCoroutine(rotateRing(_rings[i], Quaternion.Euler(rot)));
                }
            }
        }

        private IEnumerator rotateRing(GameObject ring, Quaternion newRot)
        {
            while (ring.transform.localRotation.x <= newRot.x)
            {
                ring.transform.localRotation = Quaternion.RotateTowards(ring.transform.localRotation, newRot, speed * 3 * Time.deltaTime);
                yield return null;
            }
        }

        private void LateUpdate()
        {
            foreach(GameObject ring in _rings)
                for(int i = 0; i < ring.transform.childCount; i++)
                    ring.transform.GetChild(i).RotateAround(ring.transform.position, ring.transform.up, speed * 3 * Time.deltaTime);
        }
    }

    public enum ElectronRingRotationTypes : byte
    {
        Rotation2D = 0,
        Rotation3D,
    }
}
