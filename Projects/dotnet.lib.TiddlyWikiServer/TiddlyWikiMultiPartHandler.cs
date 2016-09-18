
using System;
using dotnet.lib.CoreAnnex.log;
using dotnet.lib.Http.multi_part;
using dotnet.lib.Http.file.server;

namespace dotnet.lib.TiddlyWikiServer
{
	public class TiddlyWikiMultiPartHandler : MultiPartHandler
	{

		private static Log log = Log.getLog(typeof(FileSaveMultiPartHandler));

		string _folderPath;

		public TiddlyWikiMultiPartHandler( String folderPath )
		{
			_folderPath = folderPath;
		}

		public PartHandler FoundPartDelimiter()
		{
			return new TiddlyWikiPartHandler(_folderPath);
		}

		public void HandleException(Exception e)
		{
			log.error(e);
		}

		public void FoundCloseDelimiter()
		{
			log.enteredMethod();
		}
	}
}

