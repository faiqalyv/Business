using System;
namespace Infrastructure.Utilities.Exceptions;

public class NameNotFound : Exception
{
	public NameNotFound(String message):base(message)
	{
	}
}
