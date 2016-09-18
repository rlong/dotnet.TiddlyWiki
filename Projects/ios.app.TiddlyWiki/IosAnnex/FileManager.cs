using System;
using Foundation;

namespace IosAnnex
{
	public class FileManager
	{
		public FileManager()
		{
		}


		public static void CopyItem(String atPath, String dstPath)
		{

			NSError error = null;

			NSFileManager.DefaultManager.Copy(atPath, dstPath, out error);
			if (null != error)
			{
				throw new ErrorException(typeof( FileManager), "Copy", error);
			}				
		}
	}
}

