
#define TRACE

using System;
using System.Threading;
using dotnet.lib.CoreAnnex.log;
using dotnet.lib.Http.file.server;
using dotnet.lib.Http.headers;
using dotnet.lib.Http.server.reqest_handler;
using dotnet.lib.Http.server;
using dotnet.lib.TiddlyWikiServer;

namespace dotnet.app.TddlyWikiServer
{
	class MainClass
	{

		private static Log log = Log.getLog(typeof(MainClass));

		public static void Main (string[] args)
		{

			Log.setDelegate (new ConsoleLogDelegate (true));

			String home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			String rootFolder = home + "/Projects/dotnet.lib.TiddlyWikiServer/Projects/browser.site.TiddlyWikiApp";

			if (1 == args.Length) {
				rootFolder = args [0];
			}
			log.info (rootFolder, "rootFolder"); 

			TiddlyWikiServer server = new TiddlyWikiServer(rootFolder,rootFolder);
			server.start();

			log.info("thread 'wait'ing indefinitely");
			{

				Object indefiniteLock = new Object();
				lock (indefiniteLock)
				{
					Monitor.Wait(indefiniteLock);
				}
			}

			return;
		}

	}
}
