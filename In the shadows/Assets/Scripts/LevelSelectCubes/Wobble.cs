using UnityEngine;

public class Wobble : MonoBehaviour {

	public Vector3 WobbleAmount = new Vector3 (0.1F, 0.1F, 0.1F);
	public Vector3 WobbleSpeed = new Vector3 (0.5F, 0.5F, 0.5F);

	private Vector3 m_BasePosition;
	private Vector3 m_NoiseIndex = new Vector3();

	void Start ()
    {
		m_BasePosition = transform.position;

		m_NoiseIndex.x = Random.value;
		m_NoiseIndex.y = Random.value;
		m_NoiseIndex.z = Random.value;
	}
	
	void Update () {

		Vector3 offset = new Vector3 ();
		offset.x = Mathf.PerlinNoise(m_NoiseIndex.x, 0) - 0.5F;
		offset.y = Mathf.PerlinNoise(m_NoiseIndex.y, 0) - 0.5F;
		offset.z = Mathf.PerlinNoise(m_NoiseIndex.z, 0) - 0.5F;

		offset.Scale(WobbleAmount);

		transform.position = m_BasePosition + offset;

		m_NoiseIndex += WobbleSpeed * Time.deltaTime;
	}
}