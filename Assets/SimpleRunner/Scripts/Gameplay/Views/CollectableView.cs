using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Nashet.SimpleRunner.Gameplay.Views
{
	public class CollectablesView : MonoBehaviour, ICollectableView
	{
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnDestroy()
		{
			//todo!!! return object to pool
		}
	}
}
