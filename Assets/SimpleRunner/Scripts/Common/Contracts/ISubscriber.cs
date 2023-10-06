namespace Nashet.SimpleRunner.Contracts.Patterns
{
	public interface ISubscriber<T>
	{
		void PropertyChangedHandler(T sender, string propertyName);
	}
}