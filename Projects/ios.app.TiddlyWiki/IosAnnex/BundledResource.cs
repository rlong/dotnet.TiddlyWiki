using System;
using dotnet.lib.CoreAnnex.log;
using Foundation;

namespace IosAnnex
{
	// vvv derived from ios.app.vlc_pal:XPBundledResource
	public class BundledResource
	{

		private static Log log = Log.getLog(typeof(BundledResource));


		String _absoluteFilePath;
		String _resourcePath;

		public String AbsoluteFilePath
		{
			get
			{
				if (null != _absoluteFilePath)
				{
					return _absoluteFilePath;
				}


				_absoluteFilePath = NSBundle.MainBundle.PathForResource(_resourcePath, null);
				if (null == _absoluteFilePath)
				{
					log.warnFormat("null == _absoluteFilePath; _resourcePath = '{0}'", _resourcePath);
				}

				return _absoluteFilePath;
			}
			set 
			{
				_resourcePath = value; 
			}

		}

		//public String AbsoluteFilePath
		//{
		//}

		public BundledResource( String resourcePath )
		{
			_resourcePath = resourcePath;
		}

		public Boolean validate()
		{
			if (null == this.AbsoluteFilePath)
			{
				return false;
			}
			return true;
		}

	}
	// ^^^ derived from ios.app.vlc_pal:XPBundledResource

}

