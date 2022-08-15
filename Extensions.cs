using System;
using System.Linq;
using Exiled.API.Features;

namespace RainbowTags
{
	public static class Extensions
	{
		public static string GetGroupName(this UserGroup group)
			=> ServerStatic.GetPermissionsHandler().GetAllGroups().Where(p => p.Value == group).Select(p => p.Key)
				.FirstOrDefault();

		public static bool IsRainbowTagUser(this Player hub)
		{
			string group = ServerStatic.GetPermissionsHandler().GetUserGroup(hub.UserId)
				.GetGroupName();
			
			return !string.IsNullOrEmpty(group) && RainbowTagMod.RainbowTagRef.Config.ActiveGroups.Contains(group);
		}
	}
}