using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SensorController : MonoBehaviour, IPointerDownHandler
{
	public delegate void SensorPressHandler();
	public static SensorPressHandler OnSensorPress;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (OnSensorPress != null)
			OnSensorPress ();
	}
}
