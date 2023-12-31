﻿namespace Nashet.SimpleRunner.Contracts.Patterns
{
	/// <summary>
	/// use it togther with IPropertyChangeNotifier
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ISubscriber<T>
	{
		void PropertyChangedHandler(T sender, string propertyName);
	}
}