using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class ElectronRing : MonoBehaviour
    {
        public float speed = 10f;
        public ElectronRingRotationTypes currentRotationType = ElectronRingRotationTypes.Rotation2D;

        private List<GameObject> electrons = new List<GameObject>();

        public GameObject GenerateElectronRings(int electrons, float start)
        {
            GameObject model = new GameObject("ElectronRings");
            model.transform.parent = this.transform;
            model.transform.localPosition = Vector3.zero;

            uint ring = 1;
            float ringDist = 0;
            float electron = 0;
            List<GameObject> rings = new List<GameObject>();
            GameObject tmp = new GameObject($"ElectronRing{ring}");
            tmp.transform.parent = model.transform;

            tmp.AddComponent<Torus>();
            tmp.GetComponent<Torus>().GenerateTorus(this.transform.position, start, 0.2f);

            tmp.transform.localPosition = Vector3.zero;
            rings.Add(tmp);

            bool allElectrons = true; float amountNeeded = 0;
            for ( int i = 0; i < electrons; i++ )
            {
                float amountOfElectrons;
                if (allElectrons)
                    amountOfElectrons = 2 * (Mathf.Pow(ring, 2));
                else
                    amountOfElectrons = amountNeeded;

                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = $"Electron{electron}";
                sphere.transform.parent = rings[(int)ring - 1].transform;
                sphere.transform.localPosition = new Vector3(start + ringDist, 0, 0);
                sphere.transform.RotateAround(this.transform.position, Vector3.up, (360 / amountOfElectrons) * electron);
                sphere.GetComponent<MeshRenderer>().material.color = Color.yellow;

                this.electrons.Add(sphere);
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

                    rings.Add(tmpa);
                }
            }

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

        }

        private void LateUpdate()
        {
            foreach(GameObject electron in electrons)
                electron.transform.RotateAround(this.transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }

    public enum ElectronRingRotationTypes : byte
    {
        Rotation2D = 0,
        Rotation3D,
    }
}
