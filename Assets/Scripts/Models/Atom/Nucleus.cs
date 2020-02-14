using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Nucleus : MonoBehaviour
    {
        public float range = 1f;
        public float speed = 0.5f;

        private List<GameObject> protons = new List<GameObject>();
        private List<GameObject> neutrons = new List<GameObject>();
        private byte direction = 0;

        public GameObject GenerateNucleus(int protons, int neutrons)
        {
            range *= protons / 10;
            GameObject model = new GameObject("Nucleus");
            model.transform.parent = this.transform;
            model.transform.localPosition = Vector3.zero;

            for (int i = 0; i < protons; i++)
            {
                Vector3 pos = this.transform.position + (Random.onUnitSphere * range);

                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = $"Proton{i}";
                sphere.transform.position = pos;
                sphere.transform.parent = model.transform;
                sphere.GetComponent<MeshRenderer>().material.color = Color.blue;

                this.protons.Add(sphere);
            }

            for (int i = 0; i < neutrons; i++)
            {
                Vector3 pos = this.transform.position + (Random.onUnitSphere * range);

                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = $"Neutron{i}";
                sphere.transform.position = pos;
                sphere.transform.parent = model.transform;
                sphere.GetComponent<MeshRenderer>().material.color = Color.red;

                this.neutrons.Add(sphere);
            }

            return model;
        }

        private void LateUpdate()
        {
            foreach (GameObject proton in protons)
            {
                Vector3 pos = proton.transform.position;
                if (direction == 0)
                    pos.x += range / 100;
                else if (direction == 1)
                    pos.x -= range / 100;
                else if (direction == 2)
                    pos.y += range / 100;
                else if (direction == 3)
                    pos.y -= range / 100;
                else if (direction == 4)
                    pos.z += range / 100;
                else if (direction == 5)
                    pos.z -= range / 100;

                proton.transform.position = Vector3.Lerp(proton.transform.position, pos, speed);
            }
            foreach (GameObject neutron in neutrons)
            {
                Vector3 pos = neutron.transform.position;
                if (direction == 0)
                    pos.x += range / 100;
                else if (direction == 1)
                    pos.x -= range / 100;
                else if (direction == 2)
                    pos.y += range / 100;
                else if (direction == 3)
                    pos.y -= range / 100;
                else if (direction == 4)
                    pos.z += range / 100;
                else if (direction == 5)
                    pos.z -= range / 100;

                neutron.transform.position = Vector3.Lerp(neutron.transform.position, pos, speed);
            }

            direction++;
            if (direction == 6)
                direction = 0;
        }
    }
}
