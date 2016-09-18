using System;
using dotnet.lib.Http.file.server;
using dotnet.lib.Http.multi_part;
using dotnet.lib.Http.server;
using System.IO;
using dotnet.lib.CoreAnnex.log;


namespace dotnet.lib.TiddlyWikiServer
{
	public class TiddlyWikiPartHandler : PartHandler
	{
		private static Log log = Log.getLog(typeof(TiddlyWikiPartHandler));

		String _repositoryPath;
		FileSavePartHandler _delegate;

		public TiddlyWikiPartHandler( String repositoryPath )
		{
			_repositoryPath = repositoryPath;
			_delegate = new FileSavePartHandler(_repositoryPath);
		}

		public void HandleHeader(String name, String value)
		{
			if (name.Equals("content-disposition"))
			{

				ContentDisposition contentDisposition = ContentDisposition.buildFromString(value);
				string filename = contentDisposition.getDispositionParameter("filename", null);
				log.debug(filename, "filename");
				if (null != filename)
				{
					FileInfo fileInfo = new FileInfo(_repositoryPath + filename);
					if (!fileInfo.Exists)
					{						
						log.errorFormat("!fileInfo.Exists; fileInfo.FullName = {0}", fileInfo.FullName);
						throw HttpErrorHelper.forbidden403FromOriginator(this);
					}
				}
				_delegate.HandleHeader(name, value);
			}
		}

		public void HandleBytes(byte[] bytes, int offset, int length)
		{
			_delegate.HandleBytes(bytes, offset, length);
		}

		public void HandleException(Exception e)
		{
			_delegate.HandleException(e);
		}

		public void PartCompleted()
		{
			_delegate.PartCompleted();
		}
	}
}

