using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public static class Atom
    {
        /// <summary>
        /// Generates a model of an atom at the position specified
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="protons"></param>
        /// <param name="neutrons"></param>
        /// <param name="electrons"></param>
        /// <returns>Returns the container object that holds all of the models</returns>
        public static GameObject GenerateAtomicModel(string name, Vector3 position, Quaternion rotation, int protons, int neutrons, int electrons)
        {
            GameObject model = new GameObject(name);
            model.transform.SetPositionAndRotation(position, rotation);

            // Generate Nucleus
            model.AddComponent<Nucleus>();
            model.GetComponent<Nucleus>().GenerateNucleus(protons, neutrons);

            // Generate Electron Rings
            model.AddComponent<ElectronRing>();
            model.GetComponent<ElectronRing>().GenerateElectronRings(electrons, model.GetComponent<Nucleus>().range + 1.1f);

            float height = model.GetComponent<Nucleus>().range;
            float width = model.GetComponent<ElectronRing>().ringSpan;

            model.AddComponent<Interaction>();
            model.GetComponent<Interaction>().CreateCollision(width, height);

            return model;
        }


    }
}
