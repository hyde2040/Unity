using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


namespace Sharkbomb.View
{
	public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{

		[SerializeField] info skills;
		[SerializeField] int no;
		[SerializeField] Battle battle;
		int skn;
		//public string text;
		Vector2 a = new Vector2(300, -98);

		public void OnPointerEnter(PointerEventData eventData)
		{
			StartHover(a);
		}
		public void OnSelect(BaseEventData eventData)
		{
			StartHover(a);
		}
		public void OnPointerExit(PointerEventData eventData)
		{
			StopHover();
		}
		public void OnDeselect(BaseEventData eventData)
		{
			StopHover();
		}

		void StartHover(Vector2 position)
		{

			TooltipView.Instance.ShowTooltip(battle.mySkill[no], position);

		}
		public void StopHover()
		{
			TooltipView.Instance.HideTooltip();
		}

	}
}