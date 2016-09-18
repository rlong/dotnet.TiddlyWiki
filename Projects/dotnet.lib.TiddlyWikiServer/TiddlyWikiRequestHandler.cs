using System;
using System.IO;
using dotnet.lib.CoreAnnex.log;
using dotnet.lib.Http.headers;
using dotnet.lib.Http.multi_part;
using dotnet.lib.Http.file.server;
using dotnet.lib.Http.server;

namespace dotnet.lib.TiddlyWikiServer
{


	public class TiddlyWikiRequestHandler : RequestHandler
	{

		private static Log log = Log.getLog(typeof(TiddlyWikiRequestHandler));

		private FileGetRequestHandler _getRequestHandler;

		private string _repositoryPath;

		public TiddlyWikiRequestHandler ( String repositoryPath )
		{
			_repositoryPath = repositoryPath;

			{
				var fullPath = repositoryPath + getProcessorUri();
				log.info("fullPath", fullPath);

				if (!Directory.Exists(fullPath))
				{
					Directory.CreateDirectory(fullPath); 
				}
			}

			_getRequestHandler = new FileGetRequestHandler(_repositoryPath );
		}

		public String getProcessorUri() {
			return "/TiddlyWikiRepository";
		}

		string getBoundaryFromRequest(HttpRequest request) {
			var mediaTypeString = request.getHttpHeader ("content-type");

			if (null == mediaTypeString) {

				log.error ("null == mediaTypeString");
				throw HttpErrorHelper.badRequest400FromOriginator (this);

			}

			var mediaType = MediaType.buildFromString (mediaTypeString);
			var answer = mediaType.getParamaterValue ("boundary", null);

			if (null == answer) { 

				log.error ("null == answer");
				throw HttpErrorHelper.badRequest400FromOriginator (this);

			}

			return answer;

		}

		public HttpResponse processRequest(HttpRequest request)
		{

			log.enteredMethod();

			if (request.Method == HttpMethod.GET)
			{

				return _getRequestHandler.processRequest(request);
			}
			else if (request.Method == HttpMethod.POST)
			{

				string boundary = getBoundaryFromRequest(request);
				log.info(boundary, "boundary");

				var multiPartReader = new MultiPartReader(boundary, request.Entity);

				var multiPartHandler = new TiddlyWikiMultiPartHandler(_repositoryPath + getProcessorUri() + "/");
				multiPartReader.Process(multiPartHandler, true);

				HttpResponse answer = new HttpResponse(200);
				return answer;

			}
			throw HttpErrorHelper.methodNotImplemented501FromOriginator(this);
		}
	}
}

