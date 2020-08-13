using AutoMapper;

namespace ATM.Application
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile);
	}
}
