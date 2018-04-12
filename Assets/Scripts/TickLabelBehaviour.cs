using UnityEngine;
using UnityEngine.UI;

public class TickLabelBehaviour : MonoBehaviour,ITickListener
{
	[SerializeField]
	private Text tickText;

	private void Awake()
	{
		Contexts.sharedInstance.game.CreateEntity().AddTickListener(this);
	}

	public void TickChanged()
	{
		var tick = Contexts.sharedInstance.game.tickComponents.currentTic;
		var sec = (tick / 60) % 60;
		var min = (tick / 3600);
		var secText = sec > 9 ? "" + sec : "0" + sec;
		var minText = min > 9 ? "" + min : "0" + min;
		tickText.text = minText + ":" + secText;
	}
}
