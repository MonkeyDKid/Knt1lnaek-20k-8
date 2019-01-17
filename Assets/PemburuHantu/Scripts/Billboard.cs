using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	public Camera m_CameraA;
    public Camera m_CameraB;
    public Camera m_CameraC;
    void Update()
	{	if (PlayerPrefs.GetInt ("pos") == 1) {
			transform.LookAt(transform.position + m_CameraA.transform.rotation * Vector3.forward,
				m_CameraA.transform.rotation * Vector3.up);
	} else {
		transform.LookAt(transform.position + m_CameraB.transform.rotation * Vector3.forward,
			m_CameraB.transform.rotation * Vector3.up);
	}
        if (PlayerPrefs.GetString(Link.SEARCH_BATTLE) == "JOUSTING") {
            transform.LookAt(transform.position + m_CameraC.transform.rotation * Vector3.forward,
            m_CameraC.transform.rotation* Vector3.up);
        }
		
	}
}

