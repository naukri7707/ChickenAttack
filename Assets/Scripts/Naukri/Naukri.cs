using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Naukri
{
	public static class IO
	{
		public static void DeserializeMethod<T>(out T dst, string filePath)
		{
			FileStream fs = new FileStream(filePath, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter();
			dst = (T)bf.Deserialize(fs);
			fs.Close();
		}

		public static void SerializeMethod<T>(T src, string filePath)
		{
			FileStream fs = new FileStream(filePath, FileMode.Create);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, src);
			fs.Close();
		}

		public static void GetStage<T>(out T dst, int identify)
		{
			
			DeserializeMethod(out dst, Application.streamingAssetsPath + "/Stage/stage_" + identify.ToString("000") + ".dat");
		}

		public static void SetStage<T>(T src, int identify)
		{
			SerializeMethod(src, Application.streamingAssetsPath + "/Stage/stage_" + identify.ToString("000") + ".dat");
		}
	}
}
