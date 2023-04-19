using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_helpersBuilding", "_levelMaxPanel", "_levelUpNow", "_countHelperInstance", "_nextCountSpawnHelper", "_extraction", "_valumeExtraction", "_buttonLvlUp", "_buttonLvlUpReward", "_buttonPrice", "_levelUps", "_levelNow")]
	public class ES3UserType_WoodUpgradePanel : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WoodUpgradePanel() : base(typeof(WoodUpgradePanel)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WoodUpgradePanel)obj;
			
			writer.WritePrivateFieldByRef("_helpersBuilding", instance);
			writer.WritePrivateFieldByRef("_levelMaxPanel", instance);
			writer.WritePrivateFieldByRef("_levelUpNow", instance);
			writer.WritePrivateFieldByRef("_countHelperInstance", instance);
			writer.WritePrivateFieldByRef("_nextCountSpawnHelper", instance);
			writer.WritePrivateFieldByRef("_extraction", instance);
			writer.WritePrivateFieldByRef("_valumeExtraction", instance);
			writer.WritePrivateFieldByRef("_buttonLvlUp", instance);
			writer.WritePrivateFieldByRef("_buttonLvlUpReward", instance);
			writer.WritePrivateFieldByRef("_buttonPrice", instance);
			writer.WritePrivateField("_levelUps", instance);
			writer.WritePrivateField("_levelNow", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WoodUpgradePanel)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_helpersBuilding":
					reader.SetPrivateField("_helpersBuilding", reader.Read<DefaultNamespace.Buildings.HelperBuildng<Tree>>(), instance);
					break;
					case "_levelMaxPanel":
					reader.SetPrivateField("_levelMaxPanel", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "_levelUpNow":
					reader.SetPrivateField("_levelUpNow", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "_countHelperInstance":
					reader.SetPrivateField("_countHelperInstance", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "_nextCountSpawnHelper":
					reader.SetPrivateField("_nextCountSpawnHelper", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "_extraction":
					reader.SetPrivateField("_extraction", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "_valumeExtraction":
					reader.SetPrivateField("_valumeExtraction", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "_buttonLvlUp":
					reader.SetPrivateField("_buttonLvlUp", reader.Read<UnityEngine.UI.Button>(), instance);
					break;
					case "_buttonLvlUpReward":
					reader.SetPrivateField("_buttonLvlUpReward", reader.Read<UnityEngine.UI.Button>(), instance);
					break;
					case "_buttonPrice":
					reader.SetPrivateField("_buttonPrice", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "_levelUps":
					reader.SetPrivateField("_levelUps", reader.Read<System.Collections.Generic.List<DefaultNamespace.UI.UpgradePanel.LevelUpData>>(), instance);
					break;
					case "_levelNow":
					reader.SetPrivateField("_levelNow", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_WoodUpgradePanelArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WoodUpgradePanelArray() : base(typeof(WoodUpgradePanel[]), ES3UserType_WoodUpgradePanel.Instance)
		{
			Instance = this;
		}
	}
}