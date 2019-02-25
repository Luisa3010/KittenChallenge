using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace Valve.VR.InteractionSystem
{
    [RequireComponent( typeof(Throwable))]
    public class Slingable : MonoBehaviour
    {
        public float test = 0.3f;   
        protected Vector3 startPosition;
        protected Quaternion startRotation;
        public Slingshot slingshot;

        public void Start()
        { 
            startPosition = transform.position;
            startRotation = transform.rotation;    
        }

        public void drawBack()
        {
            print("drawn");
        }

        public void release()
        {
            print("release");
            StartCoroutine(drawPieceMoveBack());
            
        }

        IEnumerator drawPieceMoveBack()
        {
            Vector3 startPos = slingshot.transform.position + slingshot.transform.up * 0.3f - slingshot.transform.forward * 0.07f;
            Vector3 releasePos = transform.position;
            while(Vector3.Distance(transform.position,startPosition) > 0.01f)
            {
                
                transform.position = Vector3.Lerp(transform.position, startPosition, 0.5f);
                transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, 0.5f);
                yield return new WaitForEndOfFrame();
                
            }
            slingshot.shoot(releasePos);
           
        }
    }
}
