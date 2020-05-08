using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{
    class Interaction : MonoBehaviour
    {
        public void CreateCollision(float width, float height)
        {
            BoxCollider coll = this.gameObject.AddComponent<BoxCollider>();
            coll.size = new Vector3(width, height, width);
            coll.isTrigger = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Handle electron addition
            if (collision.transform.CompareTag("electron"))
                StartCoroutine(RotateIntoOrbit(collision.gameObject));
            // Handle nucleus addition
            else if (collision.transform.CompareTag("proton/neutron"))
            {

            }
            // Else we don't care for now.
        }

        private IEnumerator RotateIntoOrbit(GameObject enteringObject)
        {
            enteringObject.transform.RotateAround(this.gameObject.transform.position, this.gameObject.transform.up, 1 * Time.deltaTime);
            yield return null;
        }
    }
}
