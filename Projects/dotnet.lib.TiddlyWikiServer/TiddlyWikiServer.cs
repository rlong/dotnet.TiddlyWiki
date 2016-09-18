using System;
using dotnet.lib.CoreAnnex.log;
using dotnet.lib.Http.file.server;
using dotnet.lib.Http.headers;
using dotnet.lib.Http.server.reqest_handler;
using dotnet.lib.Http.server;
using dotnet.lib.Http.json_broker.server;
using dotnet.lib.Http.json_broker.service.test;

namespace dotnet.lib.TiddlyWikiServer
{
	public class TiddlyWikiServer
	{
		private static Log log = Log.getLog(typeof(TiddlyWikiServer));

		String _siteFolder;
		String _repositoryFolder;

		public TiddlyWikiServer( String siteFolder, String repositoryFolder )
		{
			_siteFolder = siteFolder;
			_repositoryFolder = repositoryFolder;

		}

		public void start()
		{
			log.info("settup up web server ... ");

			RootRequestHandler rootProcessor = buildRootProcessor();
			WebServer webServer = new WebServer(22023, rootProcessor);
			webServer.Start();

			log.info("web server is running on port 22023");

		}

		private RootRequestHandler buildRootProcessor(  )
		{

			FileGetRequestHandler fileRequestHandler = new FileGetRequestHandler(_siteFolder);
			fileRequestHandler.CacheControl = new CacheControl(86400); // one day

			RootRequestHandler answer = new RootRequestHandler(fileRequestHandler);

			// services ...
			{
				ServicesRequestHandler services = new ServicesRequestHandler();
				services.AddService( new TestService() );
				services.AddService(new TiddlyWikiService());
				answer.AddRequestHandler(services);
			}


			answer.AddRequestHandler(new TiddlyWikiRequestHandler(_repositoryFolder ));
			return answer;
		}

	}
}

