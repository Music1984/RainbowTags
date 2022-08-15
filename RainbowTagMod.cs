using System;
using System.Linq;
using Exiled.API.Features;
using UnityEngine;

namespace RainbowTags
{
	public class RainbowTagMod : Plugin<Config>
	{
		public static RainbowTagMod RainbowTagRef { get; private set; }
		public override string Name => nameof(RainbowTags);
		public override string Author => "FruitBoi";
		public EventHandler Handler;

		public RainbowTagMod()
		{
			RainbowTagRef = this;
		}

		public override void OnEnabled()
		{
			if (RainbowTagRef.Config.UseCustomSequence)
				RainbowTagController.Colors = RainbowTagRef.Config.CustomSequence;

			Handler = new EventHandler(this);
			Exiled.Events.Handlers.Player.Joined += Handler.OnPlayerJoinEvent;
			Exiled.Events.Handlers.Server.RoundStarted += Handler.OnRoundStartEvent;
		}

		public override void OnDisabled()
		{
			Exiled.Events.Handlers.Server.RoundStarted -= Handler.OnRoundStartEvent;
			Exiled.Events.Handlers.Player.Joined -= Handler.OnPlayerJoinEvent;
			Handler = null;
		}

		public override void OnReloaded() { }
	}
}