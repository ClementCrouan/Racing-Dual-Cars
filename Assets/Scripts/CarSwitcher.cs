using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSwitcher : MonoBehaviour
{
	public List<GameObject> vehicles;
	public Transform spawnPoints;
	public int respawnTime = 100;
	private int randomRespawnTime;
	public float leftTime;
	public bool randomRespawn = false;
	public GameObject barDeRespawnFond;
	public GameObject barDeRespawn;
	public GameObject barDeRespawnTexte;
	public Slider sliderRandomRestartTime;
	public GameObject sliderReset;
	public GameObject sliderResetTexte;

	private DriftCamera m_DriftCamera;
	private int m_VehicleId;
	float timeWait = 0;
	Rigidbody rb;

	public void Start () 
    {
		if (barDeRespawnFond != null)
			m_DriftCamera = GetComponent<DriftCamera>();
		else
		{
			rb = gameObject.GetComponent<Rigidbody>();
			transform.position = new Vector3(14.55f, -5.95f, -13.66f);
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space) && m_DriftCamera != null)
		{
			// Disable the previous vehicle.
			vehicles[m_VehicleId].SetActive(false);

			m_VehicleId = (m_VehicleId + 1) % vehicles.Count;

			vehicles[m_VehicleId].SetActive(true);

			var graph = GetComponent<GraphOverlay>();
			if (graph)
			{
				graph.vehicleBody = vehicles[m_VehicleId].GetComponent<Rigidbody>();
				graph.SetupWheelConfigs();
			}

			// Setup the new one.
			Transform vehicleT = vehicles[m_VehicleId].transform;
			Transform camRig = vehicleT.Find("CamRig");

			m_DriftCamera.lookAtTarget = camRig.Find("CamLookAtTarget");
			m_DriftCamera.positionTarget = camRig.Find("CamPosition");
			m_DriftCamera.sideView = camRig.Find("CamSidePosition");
		}

		if (respawnTime < 100)
		{
			randomRespawnTime++;
			if (randomRespawnTime > leftTime)
			{
				randomRespawnTime = 0;
				respawnTime++;
			}
		}
		/*
		if (rb != null)
			if (rb.velocity.z < 1 && rb.velocity.z > -1 && timeWait < 5)
				timeWait += Time.deltaTime;*/

		if (rb != null)
			if (rb.velocity.magnitude < 1 && timeWait < 5)
				timeWait += Time.deltaTime;

		if (rb != null)
			if (rb.velocity.magnitude > 1)
				timeWait = 0;

		if (respawnTime == 100 | !randomRespawn)
		{
			bool carAI = false;
			bool player = false;

			if (gameObject.tag == "Player" && timeWait > 5)
				carAI = true;

			if (gameObject.tag != "Player" && Input.GetKeyDown(KeyCode.M))
				player = true;

			if (player | carAI)
			{
				if (carAI)
					timeWait = 0;
				respawnTime = 0;

				Transform vehicleTransform = vehicles[m_VehicleId].transform;
				vehicleTransform.rotation = Quaternion.identity;

				Transform closest = spawnPoints.GetChild(0);

				// Find the closest spawn point.
				for (int i = 0; i < spawnPoints.childCount; ++i)
				{
					Transform thisTransform = spawnPoints.GetChild(i);

					float distanceToClosest = Vector3.Distance(closest.position, vehicleTransform.position);
					float distanceToThis = Vector3.Distance(thisTransform.position, vehicleTransform.position);

					if (distanceToThis < distanceToClosest)
					{
						closest = thisTransform;
					}
				}

				// Spawn at the closest spawn point.
#if UNITY_EDITOR
			Debug.Log("Teleporting to " + closest.name);
#endif
				vehicleTransform.rotation = closest.rotation;

				// Try refining the spawn point so it's closer to the ground.
				// Here we assume there is only one renderer.  If not, looping over all the bounds could do the trick.
				var renderer = vehicleTransform.gameObject.GetComponentInChildren<MeshRenderer>();
				// A valid car must have at least one wheel.
				var wheel = vehicleTransform.gameObject.GetComponentInChildren<WheelCollider>();

				RaycastHit hit;
				// Boxcast everything except cars.
				if (Physics.BoxCast(closest.position, renderer.bounds.extents, Vector3.down, out hit, vehicleTransform.rotation, float.MaxValue, ~(1 << LayerMask.NameToLayer("Car"))))
				{
					vehicleTransform.position = closest.position + Vector3.down * (hit.distance - wheel.radius);
				}
				else
				{
					Debug.Log("Failed to locate the ground below the spawn point " + closest.name);
					vehicleTransform.position = closest.position;
				}

				// Reset the velocity.
				var vehicleBody = vehicleTransform.gameObject.GetComponent<Rigidbody>();
				vehicleBody.velocity = Vector3.zero;
				vehicleBody.angularVelocity = Vector3.zero;
			}
		}
	}

	public void RandomRestartTime()
    {
		leftTime = sliderRandomRestartTime.value;
    }

	public void RestartCommandes()
    {
		if (randomRespawn)
		{
			if (barDeRespawn != null)
			{
				barDeRespawn.SetActive(false);
				barDeRespawnFond.SetActive(false);
				barDeRespawnTexte.SetActive(false);
				sliderReset.SetActive(false);
				sliderResetTexte.SetActive(false);
			}
			randomRespawn = false;
		}
		else
		{
			if (barDeRespawn != null)
			{
				barDeRespawn.SetActive(true);
				barDeRespawnFond.SetActive(true);
				barDeRespawnTexte.SetActive(true);
				sliderReset.SetActive(true);
				sliderResetTexte.SetActive(true);
			}
			randomRespawn = true;
		}
	}
}
