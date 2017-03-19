using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GameLib.Main.Domain.Inputs
{
	[XmlType("gamesList")]
	public class SteamGamesList
	{
		[XmlElement("steamID64")] public UInt64 SteamId64;

		[XmlElement("steamID")] public String SteamId;

		[XmlArray("games")]
		public List<SteamGameEntry> Games { get; set; }
	}

	[XmlType("game")]
	public class SteamGameEntry
	{
		[XmlElement("appID")]
		public String AppId;

		[XmlElement("name")]
		public String Name;

		[XmlElement("logo")]
		public String Logo;

		[XmlElement("storeLink")]
		public String StoreLink;
	}
}