using UnityEngine;
using System.Collections;

public class ParticlesPlayer : MonoBehaviour 
{
	public ParticleSystem particles;
	public ParticleSystem[] abc;
	public void ShowParticles(int count = 10)
	{
		particles.Emit(count);
	}

	public void StartContinuousEmission()
	{
		particles.loop = true;
		abc [0].loop = true;
		abc [0].Play ();
		particles.Play();
	}

	public void Update(){
		if (Input.GetKey (KeyCode.Space)) {
			StartContinuousEmission ();
		}
	}
	public void StopEmission()
	{
		particles.loop = false;
		particles.Stop();
		abc [0].loop = false;
		abc [0].Stop ();
	}
}
