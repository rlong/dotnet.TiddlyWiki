using System;
using Foundation;
using dotnet.lib.CoreAnnex.exception;

namespace IosAnnex
{
	public class ErrorException : BaseException
	{
		
		public ErrorException( Object originatingObject, String callingMethod, NSError error ) : base( originatingObject, error.Description )		                                                                                             
		{
		}
	}
}

