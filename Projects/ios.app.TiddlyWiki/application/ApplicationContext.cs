using System;
using System.IO;
using dotnet.lib.CoreAnnex.log;
using dotnet.lib.Http.file.server;
using dotnet.lib.Http.headers;
using dotnet.lib.Http.server.reqest_handler;
using dotnet.lib.Http.server;
using dotnet.lib.TiddlyWikiServer;
using IosAnnex;

namespace ios.app.TiddlyWiki
{
	public class ApplicationContext
	{

		private static Log log = Log.getLog(typeof(ApplicationContext));


		private static ApplicationContext _instance;




		public ApplicationContext()
		{
		}

		public static ApplicationContext Instance()
		{

			if (null == _instance)
			{
				_instance = new ApplicationContext();
			}
			return _instance;
			
		}

		public void startServer()
		{


			String home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			log.info(home, "home");


			String siteFolder;
			{
				var bundledResource = new BundledResource("browser.site.TiddlyWikiApp");
				siteFolder = bundledResource.AbsoluteFilePath;

				if (2==(1+0))
				{
					// String rootFolder = home + "/Projects/dotnet.lib.TiddlyWikiServer/Projects/browser.site.TiddlyWikiApp";
					siteFolder = "/Users/local-rlong/Projects/dotnet.lib.TiddlyWikiServer/Projects/browser.site.TiddlyWikiApp";
				}
				log.info(siteFolder, "siteFolder");
			}


			var repositoryFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			log.info(repositoryFolder, "repositoryFolder");

			setup( siteFolder, repositoryFolder );

			TiddlyWikiServer server = new TiddlyWikiServer(siteFolder, repositoryFolder);
			server.start();

		}


		private void setup( String siteFolder, String repositoryFolder )
		{
			// repository 
			{

				var wikiFolder = repositoryFolder + "/TiddlyWikiRepository";
				if (!Directory.Exists(wikiFolder))
				{
					Directory.CreateDirectory(wikiFolder);
				}

				var wikiFile = wikiFolder + "/TiddlyWiki.html";
				if( !File.Exists( wikiFile ) ) {

					var srcFile = siteFolder + "/TiddlyWikiRepository/TiddlyWiki.html";
					File.Copy(srcFile, wikiFile);
					//FileManager.CopyItem( srcFile, wikiFile );
					
				}
			}
		}

	}
}

