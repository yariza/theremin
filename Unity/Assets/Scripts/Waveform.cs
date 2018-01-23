using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveform : MonoBehaviour {

	Material _waveformMat;

	float _displacement = 0f;

	int _displacementHash;

	[SerializeField]
	float _frequency = 1f;

	int _frequencyHash;

	void Start()
	{
		_waveformMat = GetComponent<Renderer>().material;
		_displacementHash = Shader.PropertyToID("_Displacement");
		_frequencyHash = Shader.PropertyToID("_Frequency");
	}
	
	void Update()
	{
		_displacement += Time.deltaTime * _frequency;
		_displacement %= 2f * Mathf.PI;
		_waveformMat.SetFloat(_displacementHash, _displacement);
		_waveformMat.SetFloat(_frequencyHash, _frequency);
	}
}
