using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Naukri.Tools
{
	public class NConvert
	{
		public static T ConvertTo<T>(object src) where T : IConvertible
		{
			return (T)Convert.ChangeType(src, typeof(T));
		}
	}
}
