using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;

namespace RainbowTags
{
    public class EventHandler
    {
		public RainbowTagMod plugin;
		public EventHandler(RainbowTagMod plugin) => this.plugin = plugin;

		public void OnRoundStartEvent()
		{
			foreach (Player Ply in Player.List)
			{
				if (!Ply.IsRainbowTagUser())
					continue;

				AddRainbowController(Ply);
			}
		}

		public void OnPlayerJoinEvent(JoinedEventArgs ev)
		{
			if (!ev.Player.IsRainbowTagUser())
				return;

			AddRainbowController(ev.Player);
		}

		public static void AddRainbowController(Player Ply)
		{
			if (Ply.ReferenceHub.TryGetComponent(out RainbowTagController RainbowTagCtrl))
				return;

			Ply.GameObject.AddComponent<RainbowTagController>();
		}
	}
}
