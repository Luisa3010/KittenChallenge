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
        protected Vector3 startRotation;
        public Slingshot slingshot;
        public GameObject ReleasePoint;
        
       

        


        public void Start()
         {
            
            startPosition = transform.position - slingshot.transform.position;
            startRotation = transform.rotation.eulerAngles - slingshot.transform.rotation.eulerAngles ;
            
         }

        public void drawBack()
        {
           
        }

        public void release()
        {
            StartCoroutine(drawPieceMoveBack());
        }
        
        
        IEnumerator drawPieceMoveBack()
        {
            Vector3 startPos = ReleasePoint.transform.position;
            Vector3 releasePos = transform.position;
            Vector3 startRot = slingshot.transform.rotation.eulerAngles + startRotation;

            
            while(Vector3.Distance(transform.position,startPos) > 0.01f)
            {
                startPos = ReleasePoint.transform.position;
                transform.position = Vector3.Lerp(transform.position, startPos, 0.5f);

                 
                
                startRot = slingshot.transform.rotation.eulerAngles + startRotation;
                transform.rotation = Quaternion.Euler(startRot);
                yield return new WaitForEndOfFrame();
                
            }
            if (slingshot.isReadyToShoot)
            {
                slingshot.shoot(startPos);
            }
           
        }
    }
}
