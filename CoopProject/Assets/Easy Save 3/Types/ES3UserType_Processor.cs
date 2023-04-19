using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_panel", "_duration", "_сountTransformation", "_сompleted")]
	public class ES3UserType_Processor : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Processor() : base(typeof(Processor)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Processor)obj;
			
			writer.WritePrivateFieldByRef("_panel", instance);
			writer.WritePrivateField("_duration", instance);
			writer.WritePrivateField("_сountTransformation", instance);
			writer.WritePrivateField("_сompleted", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Processor)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_panel":
					reader.SetPrivateField("_panel", reader.Read<ProductPanel>(), instance);
					break;
					case "_duration":
					reader.SetPrivateField("_duration", reader.Read<System.Single>(), instance);
					break;
					case "_сountTransformation":
					reader.SetPrivateField("_сountTransformation", reader.Read<System.Int32>(), instance);
					break;
					case "_сompleted":
					reader.SetPrivateField("_сompleted", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ProcessorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ProcessorArray() : base(typeof(Processor[]), ES3UserType_Processor.Instance)
		{
			Instance = this;
		}
	}
}