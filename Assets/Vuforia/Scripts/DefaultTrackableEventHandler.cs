/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			CanvasRenderer[] hantu1 = transform.Find("Game").transform.Find("Hantu1").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] hantu2 = transform.Find("Game").transform.Find("Hantu2").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] hantu3 = transform.Find("Game").transform.Find("Hantu3").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] Nocard = transform.Find("Canvas").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] canvasComponents = transform.Find("Envi").GetComponentsInChildren<CanvasRenderer>(true);
            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }
			foreach (CanvasRenderer component in canvasComponents)
			{
				component.gameObject.SetActive (true);
			}
			foreach (CanvasRenderer component in hantu1)
			{
				component.gameObject.SetActive (true);
			}
			foreach (CanvasRenderer component in hantu2)
			{
				component.gameObject.SetActive (true);
			}
			foreach (CanvasRenderer component in hantu3)
			{
				component.gameObject.SetActive (true);
			}
			foreach (CanvasRenderer component in Nocard)
			{
				component.gameObject.SetActive (false);
			}
		//	gameObject.SetActive (true);
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			CanvasRenderer[] canvasComponents = transform.Find("Envi").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] hantu1 = transform.Find("Game").transform.Find("Hantu1").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] hantu2 = transform.Find("Game").transform.Find("Hantu2").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] hantu3 = transform.Find("Game").transform.Find("Hantu3").GetComponentsInChildren<CanvasRenderer>(true);
			CanvasRenderer[] Nocard = transform.Find("Canvas").GetComponentsInChildren<CanvasRenderer>(true);
			// Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }
			foreach (CanvasRenderer component in canvasComponents)
			{
				component.gameObject.SetActive (false);
			}
			foreach (CanvasRenderer component in hantu1)
			{
				component.gameObject.SetActive (false);
			}
			foreach (CanvasRenderer component in hantu2)
			{
				component.gameObject.SetActive (false);
			}
			foreach (CanvasRenderer component in hantu3)
			{
				component.gameObject.SetActive (false);
			}
			foreach (CanvasRenderer component in Nocard)
			{
				component.gameObject.SetActive (true);
			}
			//sgameObject.SetActive (false);
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
