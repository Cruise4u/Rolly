using System.Collections;
using UnityEngine;

namespace Assets.Resources.Code.Player
{
    public class PlayerLandingIndicator : MonoBehaviour
    {
        GameObject parentGO;

        public void LockPosition()
        {
            gameObject.transform.position = new Vector3(parentGO.transform.position.x, 0.85f, parentGO.transform.position.z);
            gameObject.transform.rotation = Quaternion.Euler(-90,0,0);
        }

        private void Awake()
        {
            parentGO = transform.parent.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            LockPosition();
        }
    }
}