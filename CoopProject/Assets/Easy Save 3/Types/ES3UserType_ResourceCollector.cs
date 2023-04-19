using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_dataResourceLog", "_dataResourceStone", "_dataResourceGold", "_dataResourceBoards", "_dataResourceIron", "_dataResourceStoneBlocks", "_dataResourceIronIgnots", "_dataResourceGoldIgnots")]
	public class ES3UserType_ResourceCollector : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ResourceCollector() : base(typeof(ResourceCollector)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ResourceCollector)obj;
			
			writer.WritePrivateField("_dataResourceLog", instance);
			writer.WritePrivateField("_dataResourceStone", instance);
			writer.WritePrivateField("_dataResourceGold", instance);
			writer.WritePrivateField("_dataResourceBoards", instance);
			writer.WritePrivateField("_dataResourceIron", instance);
			writer.WritePrivateField("_dataResourceStoneBlocks", instance);
			writer.WritePrivateField("_dataResourceIronIgnots", instance);
			writer.WritePrivateField("_dataResourceGoldIgnots", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ResourceCollector)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_dataResourceLog":
					reader.SetPrivateField("_dataResourceLog", reader.Read<System.Int32>(), instance);
					break;
					case "_dataResourceStone":
					reader.SetPrivateField("_dataResourceStone", reader.Read<System.Int32>(), instance);
					break;
					case "_dataResourceGold":
					reader.SetPrivateField("_dataResourceGold", reader.Read<System.Int32>(), instance);
					break;
					case "_dataResourceBoards":
					reader.SetPrivateField("_dataResourceBoards", reader.Read<System.Int32>(), instance);
					break;
					case "_dataResourceIron":
					reader.SetPrivateField("_dataResourceIron", reader.Read<System.Int32>(), instance);
					break;
					case "_dataResourceStoneBlocks":
					reader.SetPrivateField("_dataResourceStoneBlocks", reader.Read<System.Int32>(), instance);
					break;
					case "_dataResourceIronIgnots":
					reader.SetPrivateField("_dataResourceIronIgnots", reader.Read<System.Int32>(), instance);
					break;
					case "_dataResourceGoldIgnots":
					reader.SetPrivateField("_dataResourceGoldIgnots", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ResourceCollectorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ResourceCollectorArray() : base(typeof(ResourceCollector[]), ES3UserType_ResourceCollector.Instance)
		{
			Instance = this;
		}
	}
}