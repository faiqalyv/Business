using System;
namespace Infrastructure.Utilities.Exceptions;

public class NotExistException:Exception
{
	public NotExistException(String message):base(message)
	{
	}
}

