using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_coins")]
	public class ES3UserType_PlayerWallet : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerWallet() : base(typeof(PlayerWallet)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlayerWallet)obj;
			
			writer.WritePrivateField("_coins", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerWallet)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_coins":
					reader.SetPrivateField("_coins", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerWalletArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerWalletArray() : base(typeof(PlayerWallet[]), ES3UserType_PlayerWallet.Instance)
		{
			Instance = this;
		}
	}
}