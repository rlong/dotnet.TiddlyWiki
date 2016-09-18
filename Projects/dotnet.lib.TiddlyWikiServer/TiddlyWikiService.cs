using System;
using dotnet.lib.Http.json_broker;
using dotnet.lib.Http.json_broker.server;
using dotnet.lib.CoreAnnex.log;
using dotnet.lib.CoreAnnex.exception;
using dotnet.lib.CoreAnnex.json;

namespace dotnet.lib.TiddlyWikiServer
{
	public class TiddlyWikiService : DescribedService, ITiddlyWikiService
	{

		private static readonly Log log = Log.getLog(typeof(TiddlyWikiService));

		public static readonly String SERVICE_NAME = "TiddlyWikiService";
		public static readonly ServiceDescription SERVICE_DESCRIPTION = new ServiceDescription(SERVICE_NAME);

		private ITiddlyWikiService _delegate;

		public TiddlyWikiService()
		{
			_delegate = this;
		}

		public TiddlyWikiService( ITiddlyWikiService service )
		{
			_delegate = service;
		}

		public ServiceDescription getServiceDescription()
		{
			return SERVICE_DESCRIPTION;
		}


		public void openDefaultWiki()
		{
			log.enteredMethod();
		}

		public void ping()
		{
			log.enteredMethod();
		}

		public BrokerMessage process(BrokerMessage request)
		{
			String methodName = request.getMethodName();


			if ("openDefaultWiki".Equals(methodName))
			{
				_delegate.openDefaultWiki();

				BrokerMessage response = BrokerMessage.buildResponse(request);
				// response.getMetaData()["x"] = "y";
				return response;

				//_delegate.GetType.ToString()
			}

			if ("ping".Equals(methodName))
			{
				_delegate.ping();

				BrokerMessage response = BrokerMessage.buildResponse(request);
				return response;
			}

			throw ServiceHelper.methodNotFound(this, request);

		}

	}
}

