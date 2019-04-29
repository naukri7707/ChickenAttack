using UnityEngine;
using System.Collections;
// 引入Editor命名空間
using UnityEditor;

// 使用繪製器，如果使用了[EnumFlagsAttribute]的這種自定義特性
// 就執行下面代碼對EnumFlagsAttribute進行補充
[CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
public class EnumFlagsDrawer : PropertyDrawer
{
	public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _lable)
	{
		// attribute 是PropertyAttribute類中的一個屬性
		// EnumFlagsAttribute中的所有屬性都可以調用
		EnumFlagsAttribute flags = attribute as EnumFlagsAttribute;
		// 枚舉值的數值最後為一個數字，如果要取得其代表的或包含的數值必須通過按位運算來提取
		// 繪製出一個下拉菜單，枚舉類型
		_property.intValue = EditorGUI.MaskField(_position, flags.text, _property.intValue, _property.enumDisplayNames);
	}

}